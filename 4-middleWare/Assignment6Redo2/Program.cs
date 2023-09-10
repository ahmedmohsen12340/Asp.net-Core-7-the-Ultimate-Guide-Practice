using Assignment6Redo2.MyMiddleWares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMyAuth();
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    if (context.Request.Method == "GET")
        await context.Response.WriteAsync("No response");
});
app.Run();
