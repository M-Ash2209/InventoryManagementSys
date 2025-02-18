using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using CrudApp.Model;
using Microsoft.EntityFrameworkCore;
using Product.Domain.RepoInterfaces;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repo
{
    public class AddProductImplementation : IAddProductInterface
    {
        private readonly ProductDbContext _db;
           
        public AddProductImplementation(ProductDbContext db)
        {
            _db = db;
        }
        public async Task<int> AddProductAsync(Item item)
        {
            _db.Products.Add(item);
            await _db.SaveChangesAsync();
            return item.Id;
        }
    }
}
