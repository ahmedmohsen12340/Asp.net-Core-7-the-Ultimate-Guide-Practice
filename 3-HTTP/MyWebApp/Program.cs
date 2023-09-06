using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async(HttpContext context) =>
{
    //string s = context.Request.Path;
    //s=context.Request.Method;
    //context.Response.StatusCode = 200;
    //string s;
    //if (context.Request.Query.ContainsKey("id"))
    //{
    //    s = context.Request.Query["id"];
    //}
    //else
    //{
    //    s = context.Request.Path;
    //}
    //context.Response.Headers["PEWPEW"] = "AhmedMohsen";
    //context.Response.Headers["Date"] = "9 9 1996";
    //if (context.Request.Headers.ContainsKey("id"))
    //{
    //    string s = context.Request.Headers["id"];
    //    await context.Response.WriteAsync(s);
    //}

    //StreamReader body = new StreamReader(context.Request.Body);
    //string reader =await body.ReadToEndAsync();
    //Dictionary<string, StringValues> myDic = QueryHelpers.ParseQuery(reader);
    //await context.Response.WriteAsync(myDic["lastname"][0]);
});

app.Run();
