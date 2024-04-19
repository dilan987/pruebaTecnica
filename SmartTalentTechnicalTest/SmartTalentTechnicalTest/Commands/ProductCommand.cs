namespace SmartTalentTechnicalTest.Commands
{
    public record CreateProductCommand( string name, string description, double price, double QuantityAvailable);
    public record UpdateProductCommand(Guid productId, string name, string description, double price, double QuantityAvailable);
}
