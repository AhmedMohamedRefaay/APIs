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

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCaommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryHandler(ICategoryRepository   categoryRepository) {

            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(CreateCategoryCaommand request, CancellationToken cancellationToken)
        {
       
            Category category=new Category();
            if (request.ParentCategory!=null)
           category= await _categoryRepository.GetByIdAsyc((int)request.ParentCategory);

            using var datastream = new MemoryStream();
            await request.Images.CopyToAsync(datastream);
            var min = new Category()
            {
                NameArabic=request.NameArabic,
                Name = request.Name,
                Images = datastream.ToArray(),
              ParentCategory=category
            };

            if (min != null)
            {

            
                await _categoryRepository.CreateAsync(min);
                return true;
            }
            else
                return false;
              
        }
    }
}
