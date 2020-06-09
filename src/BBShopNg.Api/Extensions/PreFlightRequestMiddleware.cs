using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BBShopNg.Api.Extensions
{
    public class PreFlightRequestMiddleware
    {
        private readonly RequestDelegate Next;
        public PreFlightRequestMiddleware(RequestDelegate next)
        {
            Next = next;
        }
        public Task Invoke(HttpContext context)
        {
            return BeginInvoke(context);
        }
        private Task BeginInvoke(HttpContext httpContext)
        {
            
            if (httpContext.Request.Method == HttpMethod.Options.Method)
            {
                httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                httpContext.Response.Headers.Add("Access-Control-Allow-Headers",
                    "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
                httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");

                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return httpContext.Response.WriteAsync("OK");
            }
            return Next.Invoke(httpContext);
        }
    }

    public static class PreFlightRequestExtensions
    {
        public static IApplicationBuilder UsePreFlightRequestHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PreFlightRequestMiddleware>();
        }
    }
}