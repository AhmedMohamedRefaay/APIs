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
            
            
                var Orders = await _context.Orders.Include(p=>p.Products).ToListAsync();
              
           
                return Orders;
            
        }

        //public async Task<Order?> GetByIdAsyc(int id)
        //{
        //    return await _context.Orders.Include(e=>e.Products).SingleOrDefaultAsync(a=>a.Id==id);
        //}


    }
}
