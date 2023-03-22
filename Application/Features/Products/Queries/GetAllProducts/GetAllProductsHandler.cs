using Application.Contracts;

using MediatR;
using ModelDto.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAllQuery
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<MinimalProductDto>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsHandler(IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }
       

       public async Task<IEnumerable<MinimalProductDto>> Handle (GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var r = await _productRepository.FilterAsync(request.Name);
                
           return  r.Select(e => new MinimalProductDto {Id= (int)e.Id,Name=e.Name });
             

        }
    }
}
