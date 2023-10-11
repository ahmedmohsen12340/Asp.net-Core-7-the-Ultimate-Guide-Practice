using StockApp.ConfigurationOptions;
using Services;
using ServicesContract;
using Models;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using Repository;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IFinnhubService, FinnhubService>();
builder.Services.AddScoped<IFinnhubRepository, FinnhubRepository>();
builder.Services.AddScoped<IStocksService, StockService>();
builder.Services.AddScoped<IStocksRepository, StocksRepository>();
builder.Services.Configure<TradingOption>(builder.Configuration.GetSection("TradingOptions"));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider service, LoggerConfiguration configuration) =>
{
    configuration
    .ReadFrom.Configuration(context.Configuration) //read configuration settings from built-in IConfiguration (appsetting.json)
    .ReadFrom.Services(service); //read services from built-in IServiceProvider 
});

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields =
    HttpLoggingFields.RequestProperties | HttpLoggingFields.ResponsePropertiesAndHeaders;
});

var app = builder.Build();


if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if(!builder.Environment.IsEnvironment("Test"))
{
    Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotitva");
}

app.UseHttpLogging();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

//to make the code accessible for auto-generated class programs
public partial class Program { }