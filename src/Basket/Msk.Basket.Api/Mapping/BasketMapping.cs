using AutoMapper;
using Msk.Basket.Api.Entities;
using Msk.EventBusRabbitMQ.Events;

namespace Msk.Basket.Api.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
