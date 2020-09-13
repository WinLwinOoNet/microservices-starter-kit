using AutoMapper;
using Msk.EventBusRabbitMQ.Events;
using Msk.Ordering.Application.Commands;

namespace Msk.Ordering.Api.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<BasketCheckoutEvent, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
