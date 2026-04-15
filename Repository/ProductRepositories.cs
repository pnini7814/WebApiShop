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

        

        public async Task<Product?> GetProductById(int Id)
        {
            return await _webApiShopDBContext.Products.FindAsync(Id);
        }
        public async Task<(IEnumerable<Product>,int)> GetProducts(int[]? categoryId, decimal maxPrice, decimal minPrice,string des,int position, int skip)
        {
            var query = _webApiShopDBContext.Products.Where(product =>
            (des == null ? (true) : (product.Description.Contains(des))&&
            (minPrice == 0) ? (true) : (product.Price >= minPrice) &&
            (maxPrice == 0) ? (true) : (product.Price <= maxPrice) &&
            (categoryId.Length == 0) ? (true) : (categoryId.Contains(product.ProductId))))
            .OrderBy(product => product.Price);  
            List<Product> products = await query.Skip((position - 1) * skip)
            .Take(skip).Include(product => product.Category).ToListAsync();
               var total = await query.CountAsync();
            return(products, total);
        }
        public async Task<Product> CreateProducts(Product product)
        {
            await _webApiShopDBContext.Products.AddAsync(product);
            await _webApiShopDBContext.SaveChangesAsync();
            return product;
        }



    }
}
