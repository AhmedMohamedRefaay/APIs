using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {


        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categ=await _categoryRepository.GetByIdAsyc(request.Id);
            if(categ!=null)
            {
               
                categ.Name = request.Name;
                categ.Image = request.Images;
                categ.ParentCategory = request.ParentCategory;
                await _categoryRepository.UpdateAsync(categ);
                return true;
                
               
            }
            return false;

        }
    }
}
