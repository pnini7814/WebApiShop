using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepositories : IProductRepositories
    {
        WebApiShopDBContext _webApiShopDBContext;

        public ProductRepositories(WebApiShopDBContext webApiShopDBContext)
        {
            _webApiShopDBContext = webApiShopDBContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _webApiShopDBContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int Id)
        {
            return await _webApiShopDBContext.Products.FindAsync(Id);
        }
    }
}
