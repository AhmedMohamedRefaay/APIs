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
            var min = new Category()
            {
                Name = request.Name,
                Image = request.image,
                ParentCategory = request.ParentCategory
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
