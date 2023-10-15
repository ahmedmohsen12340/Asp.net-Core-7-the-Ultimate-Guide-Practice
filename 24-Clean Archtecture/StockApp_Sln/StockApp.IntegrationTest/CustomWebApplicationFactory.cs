using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace XUnitTest_StockApp.IntegrationTests
{
    /// <summary>
    /// to create a request instead of the browser in test cases it allow us to access the program file
    /// </summary>
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        //it is called automatically in runtime
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            //to change Environment
            builder.UseEnvironment("Test");

            //it allow us to deal with services
            builder.ConfigureServices(services =>
            {
                //to select service from services
                var dbcontextService = services.SingleOrDefault(temp => temp.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                if (dbcontextService != null)
                    //to remove service 
                    services.Remove(dbcontextService);

                //to add service
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    //to use in memory database instead of the real database it's created every test and to use this method you have to (install-package Microsoft.EntityFrameworkCore.InMemory) 
                    options.UseInMemoryDatabase("DataBaseForTesting");
                });

            });
            //add configuration source for the host builder
            builder.ConfigureAppConfiguration((WebHostBuilderContext ctx, IConfigurationBuilder config) =>
            {
                var newConfiguration = new Dictionary<string, string>()
                {
                     { "token", "ck2g04hr01qhd6tia670ck2g04hr01qhd6tia67g" } //add token value
                };
                config.AddInMemoryCollection(newConfiguration);
            });
            base.ConfigureWebHost(builder);
        }
    }
}
