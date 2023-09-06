var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();
Dictionary<int,string> countries = new Dictionary<int,string>();
countries.Add(1, "United States");
countries.Add(2, "Canda");
countries.Add(3, "United Kingdom");
countries.Add(4, "India");
countries.Add(5, "japan");
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync($"the path is :  {context.Request.Path}");
    });
    endpoints.MapGet("/countries",async context =>
    {
        for(int i=1;i<6;i++)
        {
            await context.Response.WriteAsync($"{i}. {countries[i]}\n");
        }
    });
    endpoints.MapGet("/countries/{countryId:int:range(1,100)}", async context =>
    {
        int s = Convert.ToInt32(context.Request.RouteValues["countryid"]);
        if (s >= 1 && s < 6)
        {
            await context.Response.WriteAsync(countries[s]);
        }
        else if(s > 1 && s < 101)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("[No Country]");
        }
    });
    endpoints.MapGet("/countries/{countryId:int:min(101)}",async context =>
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
    });
});

app.Run();
