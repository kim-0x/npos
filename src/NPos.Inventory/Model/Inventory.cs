namespace NPos.Inventory.Model
{
    public class Inventory
    {
        private readonly List<StockItem> _stockItems = [];

        public double LowStockLevel { get; set; } = 5.0;

        public StockItem[] GetStockItem(Guid productId)
        {
            return [.. _stockItems.Where(s => s.ProductId == productId)];
        }

        public StockItem[] GetStockItems()
        {
            return [.. _stockItems];
        }

        public double GetCurrentStockLevel(Guid productId)
        {
            if (_stockItems.Count == 0)
            {
                return 0.0;
            }

            return _stockItems
                .Where(s => s.ProductId == productId)
                .Sum(s => s.NumberInStock);
        }

        public bool IsLowStockLevel(Guid productId)
        {
            double currentStock = GetCurrentStockLevel(productId);
            return currentStock <= LowStockLevel;
        }

        public decimal GetLatestStockPrice(Guid productId)
        {
            var latestStockItem = GetStockItem(productId)
                .Where(s => s.NumberInStock > 0) // Get only stock in
                .OrderByDescending(s => s.CreatedAt)
                .FirstOrDefault();

            return latestStockItem?.Cost ?? 0.0m;
        }
    }
}
