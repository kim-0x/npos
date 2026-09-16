using NPos.Application.Queries;

namespace NPos.Application.Abstraction.Service
{
    public interface IInventoryService
    {
        Task CreateNewProduct(string barcode, string name, string categoryName);
        Task StockEntry(string barcode, decimal cost, double numberInStock);
        Task<decimal> GetProductCostBy(ProductQuery query);
    }
}
