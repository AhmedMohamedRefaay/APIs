using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using MediatR;
using ModelDto.CategoryDto;
using ModelDto;

namespace Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, MinimalCategoryDetails>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;
        }
 

       async Task<MinimalCategoryDetails> IRequestHandler<GetCategoryByIdQuery, MinimalCategoryDetails>.Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var r =await _categoryRepository.GetByIdAsyc(request.Id);
            
            return new MinimalCategoryDetails {Name= r.Name,Image= r.Image,Id= r.Id };

             
        }
    }
}
