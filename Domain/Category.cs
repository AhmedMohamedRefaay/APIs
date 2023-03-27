using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{

    public class Category
    {

        public int Id { get; set; }

        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        public string NameArabic { get; set; }
        public Category? ParentCategory { get; set; }

        private IList<Category> subcategories;
        public IEnumerable<Category> Subcategories { get; set; }

        private IList<Product> products;
        public IEnumerable<Product> Products { get { return products; } }

        public byte[] Images { get; set; }
      
        public Category(string name, byte[] images, string nameArabic, 
            Category? parentCategory = null)
        {
            Name = name;
            NameArabic = nameArabic;
            Images = images;
            ParentCategory = parentCategory;
            Subcategories = new List<Category>();
            products = new List<Product>();
        }
        public Category() { }

        public bool AddProduct(Product product)
        {
            var prod = products.FirstOrDefault(e => (e.Name == product.Name) ||
            (e.NameArabic == product.NameArabic));
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
            var sub = subcategories.FirstOrDefault(e => (e.Name == category.Name)
            ||(e.NameArabic==category.NameArabic));
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
