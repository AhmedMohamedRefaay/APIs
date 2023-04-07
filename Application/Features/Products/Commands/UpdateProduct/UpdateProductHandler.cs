using Application.Contracts;
using Application.Features.Categories.Commands.UpdateCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {


        private readonly IProductRepository _productRepository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var prod=await _productRepository.GetByIdAsyc(request.Id);
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
                ImagePath = filePath; ;
            if (prod != null)
            {
                prod.Name = request.Name;
                prod.NameArabic = request.NameArabic;
                prod.DiscriptionArabic = request.DescriptionArabic;
                prod.Discount = request.Discount;
                prod.Discription = request.Description;
                prod.Price = request.Price;
                prod.ImagePath = ImagePath;
                prod.CategoryId = request.CategoryId;
                await _productRepository.UpdateAsync(prod);
                return true;
                
               
            }
            return false;

        }
    }
}
