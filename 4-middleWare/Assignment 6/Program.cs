using Assignment_6.MiddleWares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen((context) =>
{
    if (context.Request.Path == "/" && context.Request.Method == "POST")
        return true;
    else
    {
        context.Response.WriteAsync("No response");
        return false;
    }
}
, app => app.UseMiddleware<Middleware>()
);
app.Run(async context =>await context.Response.WriteAsync(""));
app.Run();
