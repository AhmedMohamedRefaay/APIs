using ApiContext;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductRepository : Repository<Product, long>, IProductRepository
    {

        public ProductRepository(DBContext dBContext) : base(dBContext)
        {


        }


        public async Task<IEnumerable<Product>> FilterAsync(string? Name)
        {

            return await _context.Products.ToListAsync();
            //    (e => e.Name == null ? true : (e.Name.ToLower().Contains(Name.ToLower()))).ToListAsync();
        }



    }
}


 
