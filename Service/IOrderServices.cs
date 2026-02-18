using DTOs;

namespace Service
{
    public interface IOrderServices
    {
        Task<OrderDTO> CreateOrder(OrderDTO order);
        Task<OrderDTO?> GetOrderById(int Id);
        Task<IEnumerable<OrderDTO>> GetOrders();
        Task UpdateOrder(int id, OrderDTO order);
    }
}