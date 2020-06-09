using AutoMapper;
using BBShopNg.Api.Configuration;
using BBShopNg.Api.Extensions;
using BBShopNg.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BBShopNg.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<MeuDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentityConfiguration(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.WebApiConfig();

            services.AddSwaggerConfig();
            
            services.ResolveDependencies(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            // Middleware Order
            // https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/middleware/?view=aspnetcore-3.1#middleware-order
            
            if (env.IsDevelopment())
            {
                //app.UsePreflightRequestHandler();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UsePreflightRequestHandler();
                app.UseHsts();
            }

            // make sure it is added after app.UseStaticFiles() and app.UseSession(), and before app.UseMvc()
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseMvcConfiguration(env);
            
            app.UseSwaggerConfig(provider);

            app.AddKissLogMiddleware(Configuration);

        }
    }
}
