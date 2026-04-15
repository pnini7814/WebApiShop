using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class categoryRepositories : IcategoryRepositories
    {
        WebApiShopDBContext _webApiShopDBContext;
        public categoryRepositories(WebApiShopDBContext webApiShopDBContext)
        {
            _webApiShopDBContext = webApiShopDBContext;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _webApiShopDBContext.Categories.ToListAsync();
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await _webApiShopDBContext.Categories.AddAsync(category);
            await _webApiShopDBContext.SaveChangesAsync();
            return category;
        }
    }
}
