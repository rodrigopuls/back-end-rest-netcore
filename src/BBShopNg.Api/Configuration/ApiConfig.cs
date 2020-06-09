using BBShopNg.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BBShopNg.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            // CORS com política nomeada e middleware
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                        builder =>
                        builder
                            //.WithOrigins("http://localhost:4200")
                            //.WithOrigins("http://ng-frontend.bbshop.com.br")
                            //.WithOrigins("https://ng-frontend.bbshop.com.br")
                            //.WithOrigins("https://bbshop-ng.web.app")
                            .WithOrigins("https://site-avancado-angular.web.app")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                );
            });

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection(); // Redirecione todas as solicitações HTTP para HTTPS
            
            app.UseStaticFiles(); // Servir arquivos estáticos

            app.UseRouting(); // Roteamento de ponto de extremidade - Define e restringe as rotas de solicitação

            // CORS - global policy - assign here or on each controller
            app.UseCors("CorsPolicy");
            // OPTIONS
            app.UsePreFlightRequestHandler();

            app.UseAuthentication(); // Fornece suporte à autenticação. Determina a identidade.
            app.UseAuthorization(); // Fornece suporte de autorização. Determina se tem acesso ao recurso.

            // Adicionar pontos finais
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}