using Entities;

namespace Repository
{
    public interface IcategoryRepositories
    {
        Task<Category> CreateCategory(Category category);
        Task<IEnumerable<Category>> GetCategories();
    }
}