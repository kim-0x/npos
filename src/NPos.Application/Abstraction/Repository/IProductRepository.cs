using NPos.Application.Queries;
using NPos.Inventory.Model;

namespace NPos.Application.Abstraction.Repository
{
    public interface IProductRepository
    {
        Task<Product?> GetProductBy(ProductQuery query);
        Task<Product[]> GetProducts();
        Task<Product> SaveProduct(Product product);
        Task<ProductCategory?> GetCategoryBy(string name);
    }
}
