using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Msk.Ordering.Application.Commands;
using Msk.Ordering.Application.Mapper;
using Msk.Ordering.Application.Responses;
using Msk.Ordering.Core.Entities;
using Msk.Ordering.Core.Repositories;

namespace Msk.Ordering.Application.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _repository;

        public CheckoutOrderHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderResponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = OrderMapper.Mapper.Map<Order>(request);
            if(order == null)
                throw new ApplicationException("Order is not valid");

            order = await _repository.AddAsync(order);

            return OrderMapper.Mapper.Map<OrderResponse>(order);
        }
    }
}
