using Application.Contracts;
using MediatR;
using System;
using ModelDto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDto.CategoryDto;
using Domain;


namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCaommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository) {

            _productRepository = productRepository;
        }

        

        public async Task<bool> Handle(CreateProductCaommand request, CancellationToken cancellationToken)
        {
            var min = new Product()
            {
                Name = request.Name,
                Discription = request.Description,
                Discount= request.Discount,
               
              
            };
            if (min != null)
            {
                await _productRepository.CreateAsync(min);
                return true;
            }
            else
                return false;
              
        }
    }
}
