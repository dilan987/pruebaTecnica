using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValuesObjects.Order;
using Domain.ValuesObjects.Product;
using Domain.ValuesObjects.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        DatabaseContext db;
        public OrderRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task AddOrder(Order order)
        {
            await db.AddAsync(order);
            await db.SaveChangesAsync();
        }

        public async Task DeleteOrder(OrderId Id)
        {
            var order = await db.Orders.FindAsync((Guid)Id);
            if (order != null)
            {
                db.Orders.Remove(order);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrderById(OrderId Id)
        {
            return await db.Orders.FindAsync((Guid)Id);
        }

        public async Task<Order[]> GetOrders()
        {
            return await db.Orders.ToArrayAsync();
        }


        public async Task<Order[]> GetUserOrdersById(Guid Id)
        {
            return await db.Orders.Where(o => o.UserId == Id).ToArrayAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            db.Orders.Update(order);
            await db.SaveChangesAsync();
        }
    }
}
