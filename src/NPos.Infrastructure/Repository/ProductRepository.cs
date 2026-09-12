using Microsoft.EntityFrameworkCore;
using NPos.Infrastructure.Persistence;
using NPos.Inventory.Abstraction.Repository;
using NPos.Inventory.Model;
using NPos.Inventory.Queries;

namespace NPos.Infrastructure.Repository
{
    public class ProductRepository(NPosContext nPosContext) : IProductRepository
    {
        public async Task<Product?> GetProductBy(ProductQuery query)
        {
            return await nPosContext.Products
                 .AsNoTracking()
                 .Where(p => (query.Id == null || p.Id == query.Id || p.Barcode == query.Barcode))
                 .Include(p => p.Category)
                 .Select(p => new Product
                 {
                     Id = p.Id,
                     Barcode = p.Barcode,
                     Name = p.Name,
                     Category = ProductCategory.FromString(p.Category.Name)
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
                    Category = ProductCategory.FromString(p.Category.Name)
                })
                .ToArrayAsync();
        }

        public async Task SaveProduct(Product product)
        {
            if (product.Category is null)
            {
                nPosContext.Products.Add(new()
                {
                    Id = product.Id,
                    Barcode = product.Barcode,
                    Name = product.Name,
                });
            }
            else
            {
                var category = await nPosContext.Categories
                    .AsNoTracking()
                    .Where(c => c.Name.ToLower() == product.Category.ToString())
                    .FirstOrDefaultAsync();

                if (category is null)
                {
                    nPosContext.Products.Add(new()
                    {
                        Id = product.Id,
                        Barcode = product.Barcode,
                        Name = product.Name,
                        Category = new()
                        {
                            Id = category?.Id ?? 0,
                            Name = product.Category.ToString()
                        }
                    });
                }
                else
                {
                    nPosContext.Products.Add(new()
                    {
                        Id = product.Id,
                        Barcode = product.Barcode,
                        Name = product.Name,
                        CategoryId = category.Id
                    });
                }
            }

            await nPosContext.SaveChangesAsync();
        }
    }
}
