using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
  
    public  class Category
    {
       
        public int Id { get; set; }

        [MinLength(3),MaxLength(30)]
        public string Name { get; set; }
 
        public Category ParentCategory { get; set; }

        private IList<Category> subcategories;
        public IEnumerable<Category> Subcategories { get; set; }

        private IList<Product> products;
        public IEnumerable<Product> Products { get { return products; } }

        public Images Image { get; set; }
        public Category(string name,Images image, Category parentCategory=null)
        {
            Name = name;
            Image = image;
            ParentCategory = parentCategory;
            Subcategories=new List<Category>();
            products=new List<Product>();
        }
        public Category() : this(null,null) { }
    
        public bool AddProduct(Product product)
        {
            var prod = products.FirstOrDefault(e => e.Name == product.Name);
            if (prod == null)
            {
                products.Add(product);
                return true;
            }   
            else
            {
                return false;

            }

        }

        public bool AddSubCategory(Category category)
        {
            var sub = subcategories.FirstOrDefault(e => e.Name == category.Name);
            if (sub == null)
            {
                subcategories.Add(category);
                return true;
            }
            else
            {
                return false;

            }

        }
    }
}
