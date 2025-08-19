using Livraria.Domain.Abstractions;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.CrossCutting.DependenciesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            //var connectionString = config.GetConnectionString("DefaultConnection");

            //services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<ILivroRepository, LivroRepository>();

            return services;
        }
    }
}