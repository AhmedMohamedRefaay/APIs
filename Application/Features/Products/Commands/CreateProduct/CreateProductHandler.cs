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
        private readonly ICategoryRepository _categoryRepository;
        public CreateProductHandler(IProductRepository productRepository,ICategoryRepository categoryRepository) {

            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        

        public async Task<bool> Handle(CreateProductCaommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsyc(request.CategoryId);
            
            var min = new Product()
            {
                Name = request.Name,
                NameArabic = request.NameArabic,
                DiscriptionArabic=request.DescriptionArabic,
                Discription = request.Description,
                Discount= request.Discount,
               category=category,
               Price=request.Price,
               ImagePath=request.ImagePath

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
