namespace NPos.Inventory.Model
{
    public class StockItem
    {
        public Guid Id { get; init; }
        public double NumberInStock { get; set; }
        public decimal Cost { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
