using RoutingTraining.RoutingClasses;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myRoot"
}) ;
builder.Services.AddRouting(option =>
{
    option.ConstraintMap.Add("month", typeof(MonthConstrain));
});
var app = builder.Build();

#region GetEndPoint
//app.Use(async (context, next) =>
//{
//    Endpoint? endpoint = context.GetEndpoint();
//    if (endpoint != null)
//        await context.Response.WriteAsync(endpoint.DisplayName);
//    else
//        await context.Response.WriteAsync("First get end point is null");
//    await next();
//});
#endregion

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("hello", async x => await x.Response.WriteAsync("Hello Mohsen"));
    endpoints.MapPost("howDareYou!", 
        async context => await context.Response.WriteAsync("dam you!"));
    endpoints.Map("profiles/{account=Ahmed}/{Desc?}", async (context) =>
    {
        var rv = (string)context.Request.RouteValues["account"];
        var rv2 = context.Request.RouteValues["desc"];
        if(rv2 != null)
        {
            await context.Response.WriteAsync($"account name is: {rv}\n and accout Description is : {rv2}");
        }
        else
        {
            await context.Response.WriteAsync($"account name is: {rv}\n and accout Description is : \"there is no Description\"");
        }
    });
    endpoints.Map("{num:int}", async context =>
    {
        var r =context.Request.RouteValues["num"];
        await context.Response.WriteAsync($"the number is : {r}");
    });
    endpoints.Map("{num:bool}", async context =>
    {
        var r = context.Request.RouteValues["num"];
        await context.Response.WriteAsync($"the case is : {r}");
    });
    endpoints.Map("{num:Datetime}", async context =>
    {
        var r = context.Request.RouteValues["num"];
        await context.Response.WriteAsync($"the date is : {r}");
    });
    // {4ECBCC50-8AE1-49B0-8AD1-DE793CAA86FD}
    endpoints.Map("{num:guid}", async context =>
    {
        var r = context.Request.RouteValues["num"];
        await context.Response.WriteAsync($"the guid is : {r}");
    });
    endpoints.Map("{num:regex(^\\d{{2}}-\\d{{8}}$)}", async context =>
    {
        var x = context.Request.RouteValues["num"];
        await context.Response.WriteAsync($"the number is : {x}");
    });
    endpoints.Map("{mon:month}",async context =>
    {
        var x = context.Request.RouteValues["mon"];
        await context.Response.WriteAsync($"the month is: {x}");
    });

});
app.Run(async context =>
    await context.Response.WriteAsync($"Request are recived at: {context.Request.Path}"));
app.Run();