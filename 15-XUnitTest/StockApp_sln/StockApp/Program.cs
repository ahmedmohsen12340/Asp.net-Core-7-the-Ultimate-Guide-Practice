using StockApp.ConfigurationOptions;
using Services;
using ServicesContract;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IFinnhubService, FinnhubService>();
builder.Services.AddScoped<IStocksService, StockService>();
builder.Services.Configure<TradingOption>(builder.Configuration.GetSection("TradingOptions"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
