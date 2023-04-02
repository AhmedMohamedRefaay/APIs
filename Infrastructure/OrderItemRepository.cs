using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using ApiContext;
namespace Infrastructure
{
    public class OrderItemRepository : Repository<OrderItem, int>, IOrderItemRepository
    {
        public OrderItemRepository(DBContext context) : base(context) { }

        public async Task<IEnumerable<OrderItem>> GetAllOrdersItemAsync()
        {
            return  _context.OrderItems;
        }
    }
}
