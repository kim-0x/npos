using NPos.Application.Model;
using NPos.Inventory.Model;

namespace NPos.Application.Repository
{
    public interface IProductRepository
    {
        Task<Product?> GetProductBy(ProductQuery query);
        Task<Product[]> GetProducts();
        Task SaveProduct(Product product);
    }
}
