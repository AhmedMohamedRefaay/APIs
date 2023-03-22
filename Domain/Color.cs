using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
  public  class Color
    {
      

        public int Id { get; set; }

        public string Name { get; set; }

        public Product product { get; set; } 
        public Color(string name, Product product)
        {
            Name = name;
            this.product = product;
        }
        public Color() { }
    }
}
