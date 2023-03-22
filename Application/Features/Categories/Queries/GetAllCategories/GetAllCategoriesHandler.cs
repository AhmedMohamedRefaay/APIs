using Application.Contracts;
using MediatR;
using ModelDto.CategoryDto;
using System;
using Application.Features.Categories.Queries.GetAllCategories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<MinimalCategoryDetails>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            
            _categoryRepository = categoryRepository;
        }
       

       public async Task<IEnumerable<MinimalCategoryDetails>> Handle (GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var r = await _categoryRepository.FilterAsync(request.Name);
                
           return  r.Select(e => new MinimalCategoryDetails { Id=e.Id,Name=e.Name }).ToList();
             

        }
    }
}
