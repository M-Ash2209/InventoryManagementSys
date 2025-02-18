using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Model;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Model;
using Product.Domain.RepoInterfaces;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repo
{
    public class GetProductImpementation : IGetProductInterface
    {
        private readonly ProductDbContext _db;
        public GetProductImpementation(ProductDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<Item> GetProductByIdAsync(int id)
        {
            //var Item = await _db.Products.FindAsync(id);
            var Item = await _db.Products
                            .Include(p => p.Category)
                            .FirstOrDefaultAsync(p => p.Id == id);
#pragma warning disable CS8601 // Possible null reference assignment.
            var ItemDto = new Item
            {
                Id = Item.Id,
                Name = Item.Name,
                Description = Item.Description,
                Price = Item.Price,
                Quantity = Item.Quantity,
                CategoryId = Item.CategoryId,
                Created = Item.Created,
                Updated = Item.Updated,
                Category = Item.Category != null
                    ? new Category
                    {
                        Name = Item.Category.Name,
                        Description = Item.Category.Description
                    }
                    : null
                        };
#pragma warning restore CS8601 // Possible null reference assignment.

            return ItemDto;
        }
    }
}
