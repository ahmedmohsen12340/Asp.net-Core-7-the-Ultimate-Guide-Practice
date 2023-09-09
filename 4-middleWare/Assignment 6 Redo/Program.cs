using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
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
    else if(context.Request.Method == "POST" && !pairs.ContainsKey("email") && pairs.ContainsKey("password"))
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
    await next(context);
});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    if (context.Request.Method == "GET")
        await context.Response.WriteAsync("No response");
});

app.Run();
