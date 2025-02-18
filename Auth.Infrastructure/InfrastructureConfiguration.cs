using Auth.Domain.Interfaces;
using Auth.Domain.RepoInterfaces;
using Auth.Infrastructure.Repo;
using CrudApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepoInterface,GetUserImplementation>();
            services.AddScoped<IRegisterInterface, RegImplementation>();


            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
