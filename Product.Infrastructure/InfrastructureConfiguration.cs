using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Domain.RepoInterfaces;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repo;

namespace Product.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static void AddInfrastrutreService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGetProductInterface, GetProductImpementation>();
            services.AddScoped<IAddProductInterface, AddProductImplementation>();
            services.AddScoped<IDeleteProductInterface, DeleteProductImplementation>();
            services.AddScoped<IUpdateProductInterface, UpdateProductImplementation>();

            services.AddDbContext<ProductDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
