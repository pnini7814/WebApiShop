using DTOs;

namespace Service
{
    public interface IProductService
    {
        Task<ProductDTO?> GetProductById(int Id);
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<IEnumerable<ProductDTO>> GetProducts(int[]? categoryId, decimal maxPrice, decimal minPrice);
    }
}