using NPos.Inventory.Queries;

namespace NPos.Inventory.Abstraction.Service
{
    public interface IInventoryService
    {
        Task CreateNewProduct(string barcode, string name, string categoryName);
        Task StockEntry(string barcode, decimal cost, double numberInStock);
        Task<decimal> GetProductCostBy(ProductQuery query);
    }
}
