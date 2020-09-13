using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Msk.Ordering.Application.Mapper;
using Msk.Ordering.Application.Queries;
using Msk.Ordering.Application.Responses;
using Msk.Ordering.Core.Repositories;

namespace Msk.Ordering.Application.Handlers
{
    public class GetOrderByUserNameHandler : IRequestHandler<GetOrdersByUserNameQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByUserNameHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrdersByUserNameQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetOrdersByUserName(request.UserName);

            return OrderMapper.Mapper.Map<IEnumerable<OrderResponse>>(orders);
        }
    }
}
