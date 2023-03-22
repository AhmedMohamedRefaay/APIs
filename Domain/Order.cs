using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class Order
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }

        public DateTime DateOrder { get; set; }

        public bool OrderStatus { get; set; }

        public DateTime DeliveryDate { get; set; }

        public float ShippingPrice { get; set; }

        public float Tax { get; set; }

        public int Quantity { get; set; }

        private readonly IList<Product> Products;

        public Order() { }
        public Order
            (float totalPrice, DateTime dateOrder, bool orderStatus,
            DateTime deliveryDate, float shippingPrice, float tax, int quantity)
        {
            TotalPrice = totalPrice;
            DateOrder = dateOrder;
            OrderStatus = orderStatus;
            DeliveryDate = deliveryDate;
            ShippingPrice = shippingPrice;
            Tax = tax;
            Quantity = quantity;
            Products =new List<Product>();
        }

        public IEnumerable<Product> products { get { return Products; } }

       
        public void AddProduct(Product product)
        {
            Products.Add(product);


        }
        //public Card card { get; set; }

        
        //public ContactDetails contactDetails { get; set;}

       
        //public Buyer buyer { get; set; }
    }
}
