using DTOs;

namespace Service
{
    public interface ICategoryService
    {
        Task<CategoryDTO?> CreateCategory(CategoryDTO category);
        Task<IEnumerable<CategoryDTO>> GetCategories();
    }
}