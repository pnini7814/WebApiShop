using DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController
    {
        ICategoryService _categoriesService;
        public CategoryController(ICategoryService categoriesService)
        {
            this._categoriesService = categoriesService;
        }

        // GET: api/<CategorysController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            return await _categoriesService.GetCategories();
        }
        
    }
}
