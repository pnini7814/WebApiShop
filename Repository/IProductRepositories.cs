using Entities;

namespace Repository
{
    public interface IProductRepositories
    {
        Task<Product> CreateProducts(Product product);
        Task<Product?> GetProductById(int Id);
        Task<(List<Product> items, int total)> GetProducts(int position, int skip, int[]? categoryId, decimal maxPrice, decimal minPrice, string des);
    }
}