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


            var file = request.file;
            if (file == null || file.Length == 0)
                return false;


            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine("G:\\itiProjectFinal\\api", "Images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            string ImagePath = null;
            if (file != null)
                ImagePath = filePath;
            var min = new Category()
            {
                NameArabic=request.NameArabic,
               Name = request.Name,
           
            parentId =request.ParentCategory,
              ImagePath=ImagePath
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
