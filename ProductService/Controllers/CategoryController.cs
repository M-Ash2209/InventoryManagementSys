using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Data;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ProductDbContext _db;
        public CategoryController(ProductDbContext dbContext)
        { 
            _db = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories() 
        {
            var Categories = await _db.Categories.ToListAsync();
            return Ok(Categories);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            //var ctg = await _db.Categories.FindAsync(Id);
            var ctg = await _db.Categories
                .Include(c=>c.Items)
                .FirstOrDefaultAsync(c => c.Id == Id);
            if (ctg == null) return NotFound("No Category found against this Id.");
            return Ok(ctg);

        }
    }
}
