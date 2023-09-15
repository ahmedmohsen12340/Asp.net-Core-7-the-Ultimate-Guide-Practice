using EnvPractice;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<MyAppOption>(builder.Configuration.GetSection("myapp"));
var app = builder.Build();
builder.Host.ConfigureAppConfiguration((hostingContext, config) => {
    config.AddJsonFile("myApp.json", optional: true, reloadOnChange: true);
});


app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.Run();
