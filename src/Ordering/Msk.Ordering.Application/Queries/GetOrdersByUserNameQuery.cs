using System.Collections.Generic;
using MediatR;
using Msk.Ordering.Application.Responses;

namespace Msk.Ordering.Application.Queries
{
    public class GetOrdersByUserNameQuery : IRequest<IEnumerable<OrderResponse>>, IRequest<Unit>
    {
        public string UserName { get; set;  }

        public GetOrdersByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
