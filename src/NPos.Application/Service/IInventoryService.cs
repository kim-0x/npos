using NPos.Application.Model;
using NPos.Inventory.Model;

namespace NPos.Application.Service
{
    public interface IInventoryService
    {
        Task CreateNewProduct(string barcode, string name, ProductCategory category);
        Task StockEntry(string barcode, decimal cost, double numberInStock);
        Task<decimal> GetProductCostBy(ProductQuery query);
    }
}
