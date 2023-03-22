using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Features.Categories.Queries.GetCategoryById;
using Application.Features.Products.Queries.GetProductById;
using MediatR;
using ModelDto.CategoryDto;
using ModelDto.ProductDto;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, MinimalProductDetails>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdHandler(IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }

        

        async Task<MinimalProductDetails> IRequestHandler<GetProductByIdQuery, MinimalProductDetails>.Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var r = await _productRepository.GetByIdAsyc(request.Id);
            
            return new MinimalProductDetails { Name = r.Name, Discription = r.Discription,
                Discount = r.Discount
                //CategoryId = r.Categories.FirstOrDefault(e => e.Id == r.Id).Id
            };
        }
    }
}
