using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ModelDto.CategoryDto;

namespace Application.Features.Products.Queries.GetAllQuery
{
    public class GetAllProductsQuery:IRequest<IEnumerable<MinimalProductDto>>
    {
      public  string ? Name { set; get; }
    }
}
