using InternsManagement.Domain.Interfaces;
using InternsManagement.Infrastructure.Persistence;
using InternsManagement.Infrastucture.Repositories;
using InternsManagement.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Infrastucture
{
    public static class DepencyContainerExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddRepositories();

            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));  

            return services;
        }

        public static void AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IDirectionRepository, DirectionRepository>();
            services.AddScoped<IInternRepository, InternRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }
    }
}
