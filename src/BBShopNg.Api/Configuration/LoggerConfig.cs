using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using KissLog.Apis.v1.Listeners;
using KissLog.AspNetCore;

namespace BBShopNg.Api.Configuration
{
    public static class LoggerConfiguration
    {
        public static void AddKissLogMiddleware(this IApplicationBuilder app, IConfiguration configuration)
        {

            // make sure it is added after app.UseStaticFiles() and app.UseSession(), and before app.UseMvc()
            app.UseKissLogMiddleware(options =>
            {
                options.Listeners.Add(new KissLogApiListener(new KissLog.Apis.v1.Auth.Application(
                    configuration["KissLog.OrganizationId"],
                    configuration["KissLog.ApplicationId"])
                ));
            });

        }
    }
}