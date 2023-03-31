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
    public class CreateOrderCommand : IRequest<bool>
    {
  

       
       public  List<long> products { get; set; }

        public CreateOrderCommand(List<long> _products) 
        {
           products=_products;
        }

        public CreateOrderCommand() { }
    }
}
