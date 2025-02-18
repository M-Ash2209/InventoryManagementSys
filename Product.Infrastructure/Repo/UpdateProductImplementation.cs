using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using CrudApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Product.Domain.RepoInterfaces;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repo
{
    public class UpdateProductImplementation : IUpdateProductInterface
    {
        private readonly ProductDbContext _dbContext;
        public UpdateProductImplementation(ProductDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<Item> UpdateProductAsnyc(Item item)
        {
            var product = await _dbContext.Products.FindAsync(item.Id);
            if (product == null)
            {
                return product;
            }

            product.Name = item.Name;
            product.Description = item.Description;
            product.Price = item.Price;
            product.Quantity = item.Quantity; 
            product.Updated = DateTime.Now;

            //_context.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}
