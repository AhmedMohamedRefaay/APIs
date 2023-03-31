using Application.Contracts;
using MediatR;
using ModelDto.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
    {
        private readonly IOrderRepository _OrderRepository;

        public GetOrderDetailsQueryHandler(IOrderRepository order)
        {
            _OrderRepository = order;
        }
        public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = await _OrderRepository.GetByIdAsyc(request.Id);

            return new OrderDetailsDto(item.Id,item.OrderStatus.ToString(),item.Products) ;
        }
    }
}
