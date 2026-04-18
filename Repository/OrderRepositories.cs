using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepositories : IOrderRepositories
    {
        private readonly WebApiShopDBContext _webApiShopDBContext;
        public OrderRepositories(WebApiShopDBContext webApiShopDBContext)
        {
            _webApiShopDBContext = webApiShopDBContext;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _webApiShopDBContext.Orders.ToListAsync();
        }
        public async Task<Order?> GetOrderById(int Id)
        {
            return await _webApiShopDBContext.Orders.FindAsync(Id);
        }
        public async Task<Order> CreateOrder(Order order)
        {
            await _webApiShopDBContext.Orders.AddAsync(order);
            await _webApiShopDBContext.SaveChangesAsync();
            return order;
        }
        public async Task UpdateOrder(int id, Order orderUpdate)
        {
            _webApiShopDBContext.Orders.Update(orderUpdate);
            await _webApiShopDBContext.SaveChangesAsync();
        }
        public async Task DeletOrder(int id)
        {
            _webApiShopDBContext.Orders.ExecuteDelete();
            await _webApiShopDBContext.SaveChangesAsync();
        }
    }
}

