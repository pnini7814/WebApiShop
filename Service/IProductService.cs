using DTOs;

namespace Service
{
    public interface IProductService
    {
        Task<ProductDTO?> GetProductById(int Id);
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}