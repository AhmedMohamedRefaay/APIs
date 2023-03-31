using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public enum OrderStatus
    {
        Delivered = 1,
        Shipped = 2,
        Canceled = 3
    }
    public class Order
    {
        public int Id { get; private set; }

        public DateTime? DateOrder { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }
        public float? ShippingPrice { get; set; }

        public float? Tax { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<OrderItem>? Order_Items { get; set; }
        private readonly IList<Product> products;

        public IEnumerable<Product> Products
        {
            set
            {
                Products = value;
            }

            get
            {
                return products;
            }
        }
        public Order() { }
        public Order(IEnumerable<Product> products, string orderStatus, DateTime? dateOrder = null, DateTime? deliveryDate = null, float? shippingPrice = null, float? tax = null)
        {
            Products = products;


        }

        public Order(IEnumerable<Product> products)
        {
            Products = products;


        }


        public bool AddProducts(Product product)
        {
            var availableproduct = products.FirstOrDefault(a => a.Id == product.Id);
            if (availableproduct == null)
            {
                products.Add(product);
                return true;
            }
            else { return false; }
        }
 
        public bool Removefromproducts(Product product)
        {
            var availableproduct = products.FirstOrDefault(a => a.Name == product.Name);
            if (availableproduct == null)
            {
                return false;
            }
            else
            {
                products.Remove(product);
                return true;

            }
        }
    }
}
