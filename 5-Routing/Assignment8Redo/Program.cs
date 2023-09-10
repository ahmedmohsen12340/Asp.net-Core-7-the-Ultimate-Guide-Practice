var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<string> countries = new List<string>();
countries.AddRange(new[] {"United states","Canda","United Kingdom","India","Japan" });
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("countries", async context =>
    {
        for (int i = 0; i < countries.Count; i++)
            await context.Response.WriteAsync($"{i+1}-{countries[i]}\n");
    });
    endpoints.Map("countries/{countryId:range(1,5)}", async context =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["countryId"]);
        string country = countries[id-1];
        await context.Response.WriteAsync(country);
    });
    endpoints.Map("countries/{countryId:range(6,100)}", async context =>
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("[No Country]");
    });
    endpoints.Map("countries/{countryId:min(101)}", async context =>
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
    });
});
app.Run(async context=>{
    await context.Response.WriteAsync("Hello");
});

app.Run();
