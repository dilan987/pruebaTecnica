

namespace Domain.Entities
{
    public class ProductOrder
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double amount { get; set; }

    }
}
