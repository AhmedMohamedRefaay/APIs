using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class Product
    {
       

        public long Id { set; get; }
        [MinLength(3),MaxLength(20)]
        public string Name { set; get; }
        public string Discription  { get; set; }
        [Range(0,100)]

        public int ?Discount { get; set; }
        public int AvailUnit { get; set; }

        private IList<Color> colors;
        public IEnumerable<Color> Colors { get { return colors; } }

        private  IList<Images> images;
        public IEnumerable<Images> Images { get { return images; } }

        private IList<Category> categories;
        public IEnumerable< Category> Categories { get { return categories; } }
        public Product(  string name, string discription, int? discount)
        {
            
            Name = name;
            Discription = discription;
            Discount = discount;
            categories = new List<Category>();
            colors = new List<Color>();
            images = new List<Images>();
        

        }

        public Product() { }

        public bool AddCategory(Category category)
        {
            var cat = categories.FirstOrDefault(e => e.Name == category.Name);
            if (cat == null)
            {
                categories.Add(category);
                return true;
            }
            else
            {
                return false;

            }

        }

        public bool AddImage(Images Image)
        {
            var img = images.FirstOrDefault(e => e.URL == Image.URL);
            if (img == null)
            {
                images.Add(img);
                return true;
            }
            else
            {
                return false;

            }

        }
        public bool AddColor(Color color)
        {
            var col = colors.FirstOrDefault(e => e.Name == color.Name);
            if (col == null)
            {
                colors.Add(col);
                return true;
            }
            else
            {
                return false;

            }

        }

        private readonly IList<Order> orders;
         public IEnumerable< Order> order { get { return orders; } }


        public void AddToOrder(Order order)
        {
            orders.Add(order);
        }
        public Carrier carrier { get; set; }
        //public Seller seller { get; set; }

    

        //public IEnumerable<Review> reviews { set; get; }
        //public WishList wishList { get; set; }

        //Relation between it and shoppingcard ???????????????


        // public ShoppingCart shoppingCart { get; set; }



    }
}
