using Application.Contracts;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        //delete all order or products from order ??????????????????//
        private readonly IOrderRepository _OrderRepository;

        public DeleteOrderCommandHandler(IOrderRepository order)
        {
            _OrderRepository = order;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {

            var item = await _OrderRepository.GetByIdAsyc(request.Id);
            if (item != null)
            {
                await _OrderRepository.DeleteAsync(item.Id);
                await _OrderRepository.Save();
                return true;
            }
            else
                return false;
        }
    }
}
