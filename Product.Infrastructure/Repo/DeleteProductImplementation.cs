using Microsoft.AspNetCore.Mvc;
using Product.Domain.RepoInterfaces;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repo
{
    public class DeleteProductImplementation : IDeleteProductInterface
    {
        private readonly ProductDbContext _db;
        public DeleteProductImplementation(ProductDbContext dbContext) 
        {
            _db = dbContext;
        }

        public async Task<IActionResult> DeleteProductAsync(int Id)
        {
            var item = await _db.Products.FindAsync(Id);
            if (item == null) return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            _db.Products.Remove(item);
            await _db.SaveChangesAsync();
            return new Microsoft.AspNetCore.Mvc.OkResult();
        }
    }
}