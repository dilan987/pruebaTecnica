using Domain.Entities;
using Domain.Repositories;
using Domain.ValuesObjects.Order;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using SmartTalentTechnicalTest.Commands;
using SmartTalentTechnicalTest.Queries;
using System.Security.Cryptography;
using System.Text;

namespace SmartTalentTechnicalTest.ApplicationServices
{
    public class OrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderQueries _orderQueries;
        private readonly ProductQueries _productQueries;
        private readonly IConfiguration _configuration;
        public OrderServices(IOrderRepository repository,
            OrderQueries orderQueries, 
            IConfiguration configuration,
            ProductQueries productQueries
            ) 
        { 
            this._orderRepository = repository;
            this._orderQueries = orderQueries;
            this._configuration = configuration;
            this._productQueries = productQueries;
        }

        public async Task HandleCommand(Guid userId, CreateOrderCommand createOrder)
        {
            foreach (var product in createOrder.orderData.data)
            {
                var isAvailable = await _productQueries.ValidateProductIdAsync(product.id, product.amount);
                if (!isAvailable)
                {
                    throw new Exception($"Product {product.name} is not available");
                }
            }

            var newId = Guid.NewGuid();
            var order = new Order(OrderId.Create(newId));
            order.SetUserId(userId);
            order.SetOrderDate(OrderDate.Create(createOrder.orderDate));
            order.SetStatus(OrderStatus.Create(false));
            order.SetOrderData(createOrder.orderData.data);

            await _orderQueries.AddOrderAsync(order);

        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await _orderQueries.GetOrderIdAsync(id);
        }

        public async Task<Order[]> GetAllOrders()
        {
            return await _orderQueries.GetOrdersAsync();
        }

        public async Task<Order[]> GetAllOrdersByUserId(Guid id)
        {
            return await _orderQueries.GetOrderByUserIdAsync(id);
        }

        public async Task HandleCommand(UpdateOrderCommand updateOrder)
        {
            var order = await _orderQueries.GetOrderIdAsync(updateOrder.orderId);
            if (order != null)
            {
                order.SetOrderDate(OrderDate.Create(updateOrder.orderDate));
                order.SetStatus(OrderStatus.Create(updateOrder.status));
                order.SetOrderData(updateOrder.orderData.data);

                await _orderQueries.UpdateOrderAsync(order);
            }
        }

        public async Task DeleteOrder(Guid id)
        {
            await _orderQueries.DeleteOrderAsync(id);
        }

        public async Task SendEmailAsync(string email, string subject)
        {
            string message = "Thank you for your purchase, your order is being processed.";
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:UserName").Value));
            mail.To.Add(MailboxAddress.Parse(email));
            mail.Subject = subject;
            mail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text= message
            };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
                );

            smtp.Authenticate(_configuration.GetSection("Email:UserName").Value, _configuration.GetSection("Email:PassWord").Value);
            smtp.Send(mail);
            smtp.Disconnect(true);
        }

    }
}
