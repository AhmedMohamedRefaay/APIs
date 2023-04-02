using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ApiContext
{
    public class DBContext : IdentityDbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
       .HasMany<Product>(g => g.Products)
       .WithOne(s => s.category)
        
       .OnDelete(DeleteBehavior.Cascade);



        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //public DbSet<Order> Orders { get; set; }

        //public DbSet<Review> Reviews { get; set; }

        //public DbSet<OrderItem> OrderItems { set; get; }

         

    }
}
