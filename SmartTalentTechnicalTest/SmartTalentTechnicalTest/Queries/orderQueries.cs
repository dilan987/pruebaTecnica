using Domain.Entities;
using Domain.Repositories;
using Domain.ValuesObjects.Order;
using Domain.ValuesObjects.Product;
using Domain.ValuesObjects.User;
using Infrastructure;

namespace SmartTalentTechnicalTest.Queries
{
    public class OrderQueries
    {
        private readonly IOrderRepository _orderRepository;
        public OrderQueries(IOrderRepository orderRepository) { 

            this._orderRepository = orderRepository;
        }
        public async Task<Order> GetOrderIdAsync(Guid id)
        {
            var response = await _orderRepository.GetOrderById(OrderId.Create(id));
            return response;
        }

        public async Task<Order[]> GetOrderByUserIdAsync(Guid id)
        {
            var response = await _orderRepository.GetUserOrdersById(id);
            return response;
        }
        public async Task<Order[]> GetOrdersAsync()
        {
            var response = await _orderRepository.GetOrders();
            return response;
        }
        public async Task AddOrderAsync(Order order)
        {
            await _orderRepository.AddOrder(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateOrder(order);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            await _orderRepository.DeleteOrder(OrderId.Create(id));
        }
    }
}
