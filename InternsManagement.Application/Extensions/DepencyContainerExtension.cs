
using InternsManagement.Application.ServiceInterfaces;
using InternsManagement.Application.Services;
using InternsManagement.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManagement.Application.Extensions
{
    public static class DepencyContainerExtension
    {
        public static void AddInternsManagementServices(this IServiceCollection services)
        {
            services.AddScoped<IInternService,InternService>();
            services.AddScoped<IDirectionService, DirectionService>();
            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}
