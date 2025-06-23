using InternsManagement.WebApi.ExceptionHandlers;
using InternsManagement.Application.Extensions;
using Microsoft.OpenApi.Models;
using InternsManagement.Infrastucture;

namespace InternsManagement.WebApi
{
    public class Startup
    {
        private const string AllowedOriginSettings = "AllowedOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;// to stop deleting suffix Async in methods for corenctly web working
            });

            services.AddEndpointsApiExplorer();

            services.AddCustomExceptionsHandler();

            services.AddInfrastructure(Configuration);
            services.AddApplicationServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InternsManagement API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InternsManagement API v1");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
