using AuthService.Model;
using CrudApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserLogin> Userlogin { get; set; }
        public DbSet<SignUp> SignUp { get; set; }
    }

}
