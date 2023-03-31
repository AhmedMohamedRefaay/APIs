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

        public string NameArabic { set; get; }
        public string Discription  { get; set; }

        public Order order { set; get; }
        public string DiscriptionArabic { get; set; }
        [Range(0,100)]

        public float Price { set; get; }
        public int ?Discount { get; set; }
        public int AvailUnit { get; set; }       
        public byte[] Images { set; get; }

       public string ImagePath { set; get; }
        public  Category category { get;set; }
        public Product(  string name,string nameArabic,string DiscAraibc,
            string discription, int? discount,float Price, byte[]Images)
        {
            
            Name = name;
            NameArabic = nameArabic;
            DiscriptionArabic = DiscAraibc;
            Discription = discription;
            Discount = discount;
            this.Price = Price;
            this.Images=Images;
        }

        public Product() { }
     
 
        


       
        



    }
}
