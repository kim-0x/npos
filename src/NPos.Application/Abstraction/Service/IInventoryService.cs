using NPos.Application.Commands;
using NPos.Application.Dtos;
using NPos.Application.Queries;

namespace NPos.Application.Abstraction.Service
{
    public interface IInventoryService
    {
        Task<ProductDto> CreateNewProduct(CreateProductCommand command);
        Task<StockItemDto> StockEntry(EntryStockCommand command);
        Task<decimal> GetProductCostBy(ProductQuery query);
    }
}
