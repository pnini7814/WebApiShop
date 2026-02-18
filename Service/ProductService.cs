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
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            IEnumerable<Product> Products = await repository.GetProducts();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Products);

        }
        public async Task<ProductDTO?> GetProductById(int Id)
        {

            Product product = await repository.GetProductById(Id);
            return mapper.Map<Product, ProductDTO>(product);
        }
    }
}
