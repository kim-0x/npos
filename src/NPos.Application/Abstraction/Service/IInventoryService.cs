using NPos.Application.Commands;
using NPos.Application.Dtos;
using NPos.Application.Queries;

namespace NPos.Application.Abstraction.Service
{
    public interface IInventoryService
    {
        Task<ProductDto> CreateNewProduct(CreateProductCommand command);
        Task StockEntry(string barcode, decimal cost, double numberInStock);
        Task<decimal> GetProductCostBy(ProductQuery query);
    }
}
