using Microsoft.EntityFrameworkCore;
using NPos.Application.Abstraction.Repository;
using NPos.Infrastructure.Persistence;
using NPos.Inventory.Model;

namespace NPos.Infrastructure.Repository
{
    public class StockItemRepository(NPosContext nPosContext) : IStockItemRepository
    {
        public Task<double> GetCurrentStockLevelByProductId(Guid productId)
        {
            throw new NotImplementedException();
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

        public async Task SaveStockItem(StockItem stockItem)
        {
            nPosContext.StockItems.Add(new()
            {
                ProductId = stockItem.ProductId,
                NumberInStock = stockItem.NumberInStock,
                Cost = stockItem.Cost,
                CreatedAt = DateTime.UtcNow
            });

            await nPosContext.SaveChangesAsync();
        }
    }
}
