namespace NPos.Infrastructure.Entity
{
    public class StockItem
    {
        public Guid Id { get; set; }
        public double NumberInStock { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
