using AutoMapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service
{
    internal class AutoMapping:Profile
    {
        public AutoMapping()
        { 
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductDTO,Product>().ReverseMap().ForCtorParam("CategoryName",opt=>opt.MapFrom(src=>src.Category.CategoryName));
            CreateMap<Order,OrderDTO>().ReverseMap();
            CreateMap<OrderItem,OrderItemDTO>().ReverseMap();   
            CreateMap<Category,CategoryDTO>().ReverseMap();
        }
    }
}
