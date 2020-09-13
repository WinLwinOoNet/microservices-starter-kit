using AutoMapper;
using Msk.Ordering.Application.Commands;
using Msk.Ordering.Application.Responses;
using Msk.Ordering.Core.Entities;

namespace Msk.Ordering.Application.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap();
        }
    }
}