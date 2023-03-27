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
            using var datastream = new MemoryStream();
            await request.Images.CopyToAsync(datastream);
            if (prod != null)
            {
                prod.Name = request.Name;
                prod.NameArabic = request.NameArabic;
                prod.DiscriptionArabic = request.DescriptionArabic;
                prod.Discount = request.Discount;
                prod.Discription = request.Description;
                prod.Price = request.Price;
                prod.Images = datastream.ToArray();
                await _productRepository.UpdateAsync(prod);
                return true;
                
               
            }
            return false;

        }
    }
}
