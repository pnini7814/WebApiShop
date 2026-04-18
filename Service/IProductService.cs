using DTOs;

namespace Service
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProducts(ProductDTO product);
        Task<ProductDTO?> GetProductById(int Id);
        Task<PageResponseDTO> GetProducts(int position, int skip, int[]? categoryId, decimal maxPrice, decimal minPrice, string des);
    }
}