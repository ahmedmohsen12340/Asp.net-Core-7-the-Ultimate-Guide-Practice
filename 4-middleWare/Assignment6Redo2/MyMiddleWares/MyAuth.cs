using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Assignment6Redo2.MyMiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyAuth
    {
        private readonly RequestDelegate _next;

        public MyAuth(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            StreamReader stream = new StreamReader(context.Request.Body);
            string body = await stream.ReadToEndAsync();
            Dictionary<string, StringValues> pairs = QueryHelpers.ParseQuery(body);

            if (context.Request.Method == "POST" && pairs.ContainsKey("email") && pairs.ContainsKey("password"))
            {
                string email = pairs["email"][0];
                string password = pairs["password"][0];
                if (email == "admin@example.com" && password == "admin1234")
                    await context.Response.WriteAsync("Successful login");
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid login");
                }
            }
            else if (context.Request.Method == "POST" && !pairs.ContainsKey("email") && pairs.ContainsKey("password"))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'email'");
            }
            else if (context.Request.Method == "POST" && pairs.ContainsKey("email") && !pairs.ContainsKey("password"))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'password'");
            }
            else if (context.Request.Method == "POST" && !pairs.ContainsKey("email") && !pairs.ContainsKey("password"))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'email'\n");
                await context.Response.WriteAsync("Invalid input for 'password'\n");
            }

            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyAuthExtensions
    {
        public static IApplicationBuilder UseMyAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyAuth>();
        }
    }
}
