using Application.Contracts;
using Application.Features.Orders.Commands.DeleteOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository _OrderRepository;

        public UpdateOrderCommandHandler(IOrderRepository order)
        {
            _OrderRepository = order;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var item = await _OrderRepository.GetByIdAsyc(request.Id);
            if (item != null && request.products != null)
            {
                item.Products = request.products;

                await _OrderRepository.UpdateAsync(item);
                await _OrderRepository.Save();
                return true;
            }
            else
                return false;
        }
    }
}
