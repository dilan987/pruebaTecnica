using Domain.Entities;
using Domain.ValuesObjects.Order;
using Domain.ValuesObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(OrderId Id);
        Task<Order[]> GetUserOrdersById(Guid Id);
        Task<Order[]> GetOrders();
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(OrderId Id);
    }

}
