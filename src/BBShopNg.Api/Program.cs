using System;
using AutoMapper.Configuration;
using BBShopNg.Api.Data;
using BBShopNg.Data.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BBShopNg.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //Obtenha uma instância de contexto de banco de dados do contêiner de injeção de dependência.
                var services = scope.ServiceProvider;
                try
                {
                    var configuration = services.GetRequiredService<IConfiguration>();
                    //InitialSeed.CreateRoles(services, configuration).Wait();

                    using (var context = scope.ServiceProvider.GetRequiredService<MeuDbContext>()) 
                    {
                        DbInitializer.Initialize(context, services);
                    }

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ocorreu um erro ao propagar o banco de dados.");
                }
            }

            host.Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
