using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using RepositoryContracts;
using Serilog;
using Services;
using ServicesContract;
using StockApp.ConfigurationOptions;

namespace StockApp.HelperExtentions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Services
            services.AddControllersWithViews();
            services.AddHttpClient();
            services.AddScoped<IFinnhubGetDetailsService, FinnhubGetDetailsService>();
            services.AddScoped<IFinnhubGetCompaniesDataService,FinnhubGetCompaniesDataService>();
            services.AddScoped<IFinnhubSearchService, FinnhubSearchService>();
            services.AddScoped<IFinnhubRepository, FinnhubRepository>();
            services.AddScoped<IStocksCreateBuyOrderService, StocksCreateBuyOrderService>();
            services.AddScoped<IStocksCreateSellOrderService, StocksCreateSellOrderService>();
            services.AddScoped<IStocksGetBuyOrdersService, StocksGetBuyOrdersService>();
            services.AddScoped<IStocksGetSellOrdersService, StocksGetSellOrdersService>();
            services.AddScoped<IStocksRepository, StocksRepository>();
            services.Configure<TradingOption>(configuration.GetSection("TradingOptions"));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });



            services.AddHttpLogging(options =>
            {
                options.LoggingFields =
                HttpLoggingFields.RequestProperties | HttpLoggingFields.ResponsePropertiesAndHeaders;
            });
            return services;
        }
    }
}
