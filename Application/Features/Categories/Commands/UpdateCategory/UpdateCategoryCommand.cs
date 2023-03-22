using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain;
namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Name { set; get; }

        public Images? Images { set; get; }
        public Category? ParentCategory { set; get; }
        public UpdateCategoryCommand(int id, string? name, Images? images)
        {
            Id = id;
            Name = name;
            Images = images;
            
        }

        

       

        
    }
}
