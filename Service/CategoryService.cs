using AutoMapper;
using DTOs;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IcategoryRepositories _repository;

        private readonly IMapper _mapper;

        public CategoryService(IcategoryRepositories repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            IEnumerable<Category> categories = await _repository.GetCategories();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
        }
        public async Task<CategoryDTO?> CreateCategory(CategoryDTO category)
        {
            Category category1 = _mapper.Map<CategoryDTO, Category>(category);
            category1 = await _repository.CreateCategory(category1);
            return _mapper.Map<Category, CategoryDTO>(category1);
        }
    }
}
