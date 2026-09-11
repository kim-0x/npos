using NPos.Inventory.Abstraction.Repository;
using NPos.Inventory.Abstraction.Service;
using NPos.Inventory.Exceptions;
using NPos.Inventory.Model;
using NPos.Inventory.Queries;

namespace NPos.Application.Service
{
    public class InventoryService(
        IProductRepository productRepository,
        IStockItemRepository stockItemRepository) : IInventoryService
    {
        public async Task CreateNewProduct(string barcode, string name, ProductCategory category)
        {
            Product product = new()
            {
                Barcode = barcode,
                Name = name,
                Category = category
            };

            await productRepository.SaveProduct(product);
        }

        public async Task<decimal> GetProductCostBy(ProductQuery query)
        {
            var product = await productRepository.GetProductBy(query)
                ?? throw new ProductNotFoundException($"Product with barcode '{query.Barcode}' not found in product catalog.");

            return await stockItemRepository.GetLatestItemCostById(product.Id);
        }

        public async Task StockEntry(string barcode, decimal cost, double numberInStock)
        {
            ProductQuery query = new(null, barcode);
            var product = await productRepository.GetProductBy(query)
                ?? throw new ProductNotFoundException($"Product with barcode '{query.Barcode}' not found in product catalog.");

            StockItem stockItem = new()
            {
                ProductId = product.Id,
                Cost = cost,
                NumberInStock = numberInStock
            };

            await stockItemRepository.SaveStockItem(stockItem);
        }
    }
}
