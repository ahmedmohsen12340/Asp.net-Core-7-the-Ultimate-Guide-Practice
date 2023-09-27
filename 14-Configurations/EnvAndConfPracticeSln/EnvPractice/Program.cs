using EnvPractice;
using EnvPractice.Services;
using EnvPractice.ServicesContracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.Configure<MyAppOption>(builder.Configuration.GetSection("myapp"));
builder.Host.ConfigureAppConfiguration((hostingContext, config) => {
    config.AddJsonFile("myApp.json", optional: true, reloadOnChange: true);
});
builder.Services.AddScoped<IFinnhubService, FinnhubService>();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.Run();
