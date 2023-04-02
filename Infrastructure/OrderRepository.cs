using ApiContext;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
  
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(DBContext context) : base(context) { }

       

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {


            return _context.Orders.ToList();

        }
        public List<Order> GetAllByUserID(int UserID)
        {
            return _context.Orders.Include(d => d.Order_Items).ThenInclude(i => i.Product).Where(o => o.UserID == UserID).ToList();
        }
        

        


    }
}
