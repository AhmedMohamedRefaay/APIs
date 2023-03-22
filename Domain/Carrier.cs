using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Carrier
    { 
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email{ get; set; }

        public long MobileNumber { get; set; }

        private readonly IList<Product>Products;
        public IEnumerable<Product> products { get; set; }
        public Carrier(string name, string email, long mobileNumber)
        {
            Name = name;
            Email = email;
            MobileNumber = mobileNumber;
           Products = new List<Product>();
        }
        public Carrier() { }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

       
    }
}
