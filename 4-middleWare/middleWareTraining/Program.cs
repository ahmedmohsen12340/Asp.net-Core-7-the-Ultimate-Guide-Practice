using middleWareTraining.MiddleWares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MiddleWareClass>();
var app = builder.Build();

app.Use(async(HttpContext context,RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello MW1\n");
    await next(context);
    await context.Response.WriteAsync("MW1 again\n");
});
app.UseMiddleware();
app.Run(async (context) =>
{
    await context.Response.WriteAsync("the end of Run!\n");
});

app.Run();
