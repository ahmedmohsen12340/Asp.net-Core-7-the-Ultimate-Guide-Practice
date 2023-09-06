using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment_6.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            StreamReader body =new StreamReader(httpContext.Request.Body);
            string reader=await body.ReadToEndAsync();
            Dictionary<string,StringValues> auth = QueryHelpers.ParseQuery(reader);
            if (auth.ContainsKey("email"))
            {
                if (auth.ContainsKey("password"))
                {
                    if (auth["password"][0] == "admin1234")
                    {
                        await httpContext.Response.WriteAsync("Successful login");
                    }
                    else
                    {
                        httpContext.Response.StatusCode = 400;
                        await httpContext.Response.WriteAsync("Invalid login");
                    }
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid input for 'password'");
                }
            }
            else
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("Invalid input for 'email'\n");
                if (!auth.ContainsKey("password"))
                {
                    await httpContext.Response.WriteAsync("Invalid input for 'password'");
                }
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}

