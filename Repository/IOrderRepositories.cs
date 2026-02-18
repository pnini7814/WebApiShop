using Entities;

namespace Repository
{
    public interface IOrderRepositories
    {
        Task<Order> CreateOrder(Order order);
        Task DeletOrder(int id);
        Task<Order?> GetOrderById(int Id);
        Task<IEnumerable<Order>> GetOrders();
        Task UpdateOrder(int id, Order orderUpdate);
    }
}