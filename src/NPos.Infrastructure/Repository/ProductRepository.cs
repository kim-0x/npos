using Microsoft.EntityFrameworkCore;
using NPos.Application.Abstraction.Repository;
using NPos.Application.Queries;
using NPos.Infrastructure.Persistence;
using NPos.Inventory.Model;

using ProductEntity = NPos.Infrastructure.Entity.Product;

namespace NPos.Infrastructure.Repository
{
    public class ProductRepository(NPosContext nPosContext) : IProductRepository
    {
        public async Task<ProductCategory?> GetCategoryBy(string name)
        {
            return await nPosContext.Categories
                    .AsNoTracking()
                    .Where(c => c.Name.ToLower() == name.ToLower())
                    .Select(c => new ProductCategory
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .FirstOrDefaultAsync();
        }

        public async Task<Product?> GetProductBy(ProductByKeysQuery query)
        {
            return await nPosContext.Products
                 .AsNoTracking()
                 .Where(p => (p.Id == query.Id || p.Barcode == query.Barcode))
                 .Include(p => p.Category)
                 .Select(p => new Product
                 {
                     Id = p.Id,
                     Barcode = p.Barcode,
                     Name = p.Name,
                     Category = new()
                     {
                         Id = p.Category.Id,
                         Name = p.Category.Name
                     }
                 })
                 .FirstOrDefaultAsync();
        }

        public Task<Product[]> GetProducts()
        {
            return nPosContext.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Take(1000)
                .Select(p => new Product
                {
                    Id = p.Id,
                    Barcode = p.Barcode,
                    Name = p.Name,
                    Category = new()
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name
                    }
                })
                .ToArrayAsync();
        }

        public async Task<Product> SaveProduct(Product product)
        {
            ProductEntity productEntity = (product.Category.Id == default)
                ? new()
                {
                    Barcode = product.Barcode,
                    Name = product.Name,
                    Category = new()
                    {
                        Name = product.Category.Name
                    }
                }
                : new()
                {
                    Barcode = product.Barcode,
                    Name = product.Name,
                    CategoryId = product.Category.Id
                };

            nPosContext.Products.Add(productEntity);
            await nPosContext.SaveChangesAsync();
            product.Id = productEntity.Id;
            return product;
        }
    }
}
