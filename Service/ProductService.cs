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
    public class ProductService : IProductService
    {
        IProductRepositories repository;
        IMapper mapper;
        public ProductService(IProductRepositories repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductDTO?> GetProductById(int Id)
        {
            Product product = await repository.GetProductById(Id);
            return mapper.Map<Product, ProductDTO>(product);
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts(int[]? categoryId, decimal maxPrice, decimal minPrice)
        {
            IEnumerable<Product> products = await repository.GetProducts(categoryId, maxPrice, minPrice);
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
        }
        public async Task<ProductDTO> CreateProducts(ProductDTO product)
        {
            Product Product1 = mapper.Map<ProductDTO, Product>(product);
            Product1 = await repository.CreateProducts(Product1);
            return mapper.Map<Product, ProductDTO>(Product1);
        }


   
    }
}
