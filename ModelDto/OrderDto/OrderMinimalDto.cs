using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.OrderDto
{
    public class OrderMinimalDto
    {
        public int Id { get; set; }
        
        public string? OrderStatus { get; set; }
        public List<long> ProductId { get; set; }
    }
}
