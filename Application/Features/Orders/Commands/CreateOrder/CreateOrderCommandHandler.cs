using Application.Contracts;
using Domain;
using MediatR;
using ModelDto.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IProductRepository _ProductRepository;
        public CreateOrderCommandHandler(IOrderRepository order, IProductRepository _ProductRepo)
        {
            _OrderRepository = order;
            _ProductRepository = _ProductRepo;
        }

       

         async Task<bool> IRequestHandler<CreateOrderCommand, bool>.Handle(CreateOrderCommand request,
             CancellationToken cancellationToken)
        {
            List<Product> products = new List<Product>() ;
           
            for (int i = 0; i < request.products.Count(); i++)
            {
                Product r=await _ProductRepository.GetByIdAsyc(request.products[i]);
                products.Add(r);
                
            }
             Order item = new Order(products);
            if (item != null)
            {
                await _OrderRepository.CreateAsync(item);
                return true;
            }
            else
                return false;
        }
    }

}

