using NPos.Inventory.Model;

namespace NPos.Application.Repository
{
    public interface IStockItemRepository
    {
        Task<StockItem[]> GetStockItemsByProductId(Guid productId);
        Task<double> GetCurrentStockLevelByProductId(Guid productId);
        Task<decimal> GetLatestItemCostById(Guid productId);
        Task SaveStockItem(StockItem stockItem);
    }
}
