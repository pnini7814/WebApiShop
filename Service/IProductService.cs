using DTOs;

namespace Service
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProducts(ProductDTO product);
        Task<ProductDTO?> GetProductById(int Id);
        Task<IEnumerable<ProductDTO>> GetProducts(int[]? categoryId, decimal maxPrice, decimal minPrice);
    }
}