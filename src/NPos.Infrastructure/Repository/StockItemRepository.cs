using Microsoft.EntityFrameworkCore;
using NPos.Application.Abstraction.Repository;
using NPos.Infrastructure.Persistence;
using NPos.Inventory.Model;

using StockItemEntity = NPos.Infrastructure.Entity.StockItem;

namespace NPos.Infrastructure.Repository
{
    public class StockItemRepository(NPosContext nPosContext) : IStockItemRepository
    {
        public async Task<double> GetCurrentStockLevelByProductId(Guid productId)
        {
            return await nPosContext.StockItems
                .AsNoTracking()
                .Where(s => s.ProductId == productId)
                .SumAsync(s => s.NumberInStock);
        }

        public async Task<decimal> GetLatestItemCostById(Guid productId)
        {
            return await nPosContext.StockItems
                .AsNoTracking()
                .Where(s => s.ProductId == productId && s.NumberInStock > 0)
                .OrderByDescending(s => s.CreatedAt)
                .Take(1)
                .Select(s => s.Cost)
                .FirstOrDefaultAsync();
        }

        public Task<StockItem[]> GetStockItemsByProductId(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<StockItem> SaveStockItem(StockItem stockItem)
        {
            StockItemEntity entity = new()
            {
                ProductId = stockItem.ProductId,
                NumberInStock = stockItem.NumberInStock,
                Cost = stockItem.Cost,
                CreatedAt = DateTime.UtcNow
            };

            nPosContext.StockItems.Add(entity);
            await nPosContext.SaveChangesAsync();

            return new StockItem
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                NumberInStock = entity.NumberInStock,
                Cost = entity.Cost,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
