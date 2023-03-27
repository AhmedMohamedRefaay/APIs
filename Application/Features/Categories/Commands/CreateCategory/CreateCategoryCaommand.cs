﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDto.CategoryDto;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCaommand : IRequest<bool>
    {

        public string Name { set; get; }

        public string NameArabic { set; get; }
        public int? ParentCategory { set; get; }

       
        public IFormFile Images{ set; get; }

        public CreateCategoryCaommand(string Name,string NameArabic, IFormFile Images,int? ParentCategory=null)
        {
            this.NameArabic = NameArabic;
            this.Name = Name;
            this.ParentCategory = ParentCategory;
            this.Images = Images;
        }
        public CreateCategoryCaommand() { }
       
    }
}
