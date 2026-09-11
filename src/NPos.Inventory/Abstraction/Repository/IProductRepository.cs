using NPos.Inventory.Model;
using NPos.Inventory.Queries;

namespace NPos.Inventory.Abstraction.Repository
{
    public interface IProductRepository
    {
        Task<Product?> GetProductBy(ProductQuery query);
        Task<Product[]> GetProducts();
        Task SaveProduct(Product product);
    }
}
