using Domain.ValuesObjects.Order;
using Domain.ValuesObjects.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; init; }
        public Guid UserId { get; private set; }
        public OrderDate OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<ProductOrder> OrderData { get; private set; }


        public User User { get; private set; }
        public Order(Guid id)
        {
            this.Id = id;
        }
      
        public void SetOrderDate(OrderDate orderDate)
        {
            OrderDate = orderDate;
        }
        public void SetStatus(OrderStatus status)
        {
            Status = status;
        }

        public void SetOrderData(List<ProductOrder> orderData)
        {
            OrderData = orderData;
        }

        public void SetUserId(Guid userId)
        {
            UserId = userId;
        }
    }
}
