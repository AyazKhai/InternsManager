using InternsManagement.Domain.Interfaces;
using InternsManagement.Infrastucture.Repositories;
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
        public static void AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IDirectionRepository, DirectionRepository>();
            services.AddScoped<IInternRepository, InternRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }
    }
}
