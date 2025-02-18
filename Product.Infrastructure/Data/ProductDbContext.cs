using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Model;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Model;

namespace Product.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<Item> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}