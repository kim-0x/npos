using NPos.Application.Abstraction.Repository;
using NPos.Application.Abstraction.Service;
using NPos.Application.Commands;
using NPos.Application.Dtos;
using NPos.Application.Queries;
using NPos.Inventory.Exceptions;
using NPos.Inventory.Model;

namespace NPos.Application.Service
{
    public class InventoryService(
        IProductRepository productRepository,
        IStockItemRepository stockItemRepository) : IInventoryService
    {
        public async Task<ProductDto> CreateNewProduct(CreateProductCommand command)
        {
            if (string.IsNullOrEmpty(command.CategoryName) || string.IsNullOrWhiteSpace(command.CategoryName))
            {
                throw new InvalidCategoryException(command.CategoryName);
            }

            var category = await productRepository.GetCategoryBy(command.CategoryName);

            Product product = new()
            {
                Barcode = command.Barcode,
                Name = command.Name,
                Category = (category is not null) ? category : new ProductCategory { Name = command.CategoryName },
            };

            var result = await productRepository.SaveProduct(product);

            return new ProductDto
            {
                Id = result.Id,
                Barcode = result.Barcode,
                Name = result.Name,
                Category = result.Category.Name
            };
        }

        public async Task<decimal> GetProductCostBy(ProductQuery query)
        {
            var product = await productRepository.GetProductBy(query)
                ?? throw new ProductNotFoundException($"Product with barcode '{query.Barcode}' not found in product catalog.");

            return await stockItemRepository.GetLatestItemCostById(product.Id);
        }

        public async Task<StockItemDto> StockEntry(EntryStockCommand command)
        {
            ProductQuery query = new(null, command.Barcode);
            var product = await productRepository.GetProductBy(query)
                ?? throw new ProductNotFoundException($"Product with barcode '{query.Barcode}' not found in product catalog.");

            StockItem stockItem = new()
            {
                ProductId = product.Id,
                Cost = command.Cost,
                NumberInStock = command.Quantity
            };

            var result = await stockItemRepository.SaveStockItem(stockItem);
            var numberInStock = await stockItemRepository.GetCurrentStockLevelByProductId(product.Id);
            var cost = await stockItemRepository.GetLatestItemCostById(product.Id);

            return new StockItemDto
            {
                Id = result.Id,
                ProductId = result.ProductId,
                Barcode = product.Barcode,
                Cost = cost,
                NumberInStock = numberInStock,
                CreatedAt = result.CreatedAt
            };
        }
    }
}
