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
    public class OrderServices : IOrderServices
    {
        IOrderRepositories repository;
        IMapper mapper;
        public OrderServices(IOrderRepositories repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            IEnumerable<Order> orders = await repository.GetOrders();
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);

        }
        public async Task<OrderDTO?> GetOrderById(int Id)
        {
            Order order = await repository.GetOrderById(Id);
            return mapper.Map<Order, OrderDTO>(order);
        }
        public async Task<OrderDTO> CreateOrder(OrderDTO order)
        {
            Order order1 = mapper.Map<OrderDTO, Order>(order);
            order1 = await repository.CreateOrder(order1);
            return mapper.Map<Order, OrderDTO>(order1);
        }
        public async Task UpdateOrder(int id, OrderDTO order)
        {
            Order order1 = mapper.Map<OrderDTO, Order>(order);
            await repository.UpdateOrder(id, order1);
        }
        public async Task DeletOrder(int id)
        {        
            await repository.DeletOrder(id);
        }
    }
}

