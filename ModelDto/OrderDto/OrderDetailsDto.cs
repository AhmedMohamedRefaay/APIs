using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.OrderDto
{
    public class OrderDetailsDto
    {
       

        public int Id { get; set; }
       
        public string OrderStatus { get; set; }
        public IEnumerable<Product> Products { get; set; }
       
        public DateTime? DateOrder { get; set; }
    
        public DateTime? DeliveryDate { get; set; }
        public float? ShippingPrice { get; set; }
       public float? Tax { get; set; }

        public OrderDetailsDto(int id, string orderStatus, IEnumerable<Product> products, DateTime? dateOrder = null, DateTime? deliveryDate = null, float? shippingPrice = null, float? tax = null)
        {
            Id = id;
           
            OrderStatus = orderStatus;
            Products = products;
           

        }




    }
}
