using BBShopNg.Api.Extensions;
using BBShopNg.Business.Intefaces;
using BBShopNg.Business.Notificacoes;
using BBShopNg.Business.Services;
using BBShopNg.Data.Context;
using BBShopNg.Data.Repository;
using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BBShopNg.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            // Injeção do Contexto HTTP
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped((context) =>
            {
                return Logger.Factory.Get();
            });

            // Aspnet User
            services.AddScoped<IUser, AspNetUser>();

            // Swagger
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // Mail
            //services.Configure<EmailSettings>(configuration.GetSection("SMTP"));
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}