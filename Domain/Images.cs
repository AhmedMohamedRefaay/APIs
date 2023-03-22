using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain
{
   public class Images
    {

         
        public int  Id { get; set; }

        public string URL { get; private set; }

        public int Width { get;private set; }

        public int height { get;private set; }

        public float Length { get; private set; }

        public Product product { get;private set; }
        public Images(string uRL, int width, int height, float length, Product product)
        {
            URL = uRL;
            Width = width;
            this.height = height;
            Length = length;
            this.product = product;
        }
        public Images() { }

    }
}
