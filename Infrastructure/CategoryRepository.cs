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
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(DBContext dBContext) : base(dBContext)
        {


        }



        public async Task<IEnumerable<Category>> FilterAsync(string? Name)
        {
            return await _context.Categories.ToListAsync();
        }
 
    }
}
