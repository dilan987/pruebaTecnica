using SmartTalentTechnicalTest.Dtos;

namespace SmartTalentTechnicalTest.Commands
{
    public record CreateOrderCommand( DateTime orderDate, orderDto orderData);
    public record UpdateOrderCommand(Guid orderId, DateTime orderDate, Boolean status, orderDto orderData);
}
