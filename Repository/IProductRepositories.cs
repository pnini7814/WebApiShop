using Entities;

namespace Repository
{
    public interface IProductRepositories
    {
        Task<Product?> GetProductById(int Id);
        Task<IEnumerable<Product>> GetProducts();
    }
}