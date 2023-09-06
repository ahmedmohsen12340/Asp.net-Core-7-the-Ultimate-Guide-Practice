var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async(HttpContext Context) =>
{
    if(!Context.Request.Query.ContainsKey("firstNumber")||
    !Context.Request.Query.ContainsKey("secondNumber") ||
    !Context.Request.Query.ContainsKey("operation")
    )
    {
        Context.Response.StatusCode = 400;
    }
    int result;
    int fn = int.MinValue, ln = int.MinValue;
    if (Context.Request.Query.ContainsKey("firstNumber"))
    {
        fn = Convert.ToInt32(Context.Request.Query["firstNumber"]);
    }
    else
    {
        await Context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
    }
    if (Context.Request.Query.ContainsKey("secondNumber"))
    {
        ln = Convert.ToInt32(Context.Request.Query["secondNumber"]);
    }
    else
    {
        await Context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
    }
    if (Context.Request.Query.ContainsKey("operation"))
    {
        string op = Context.Request.Query["operation"];
        switch (op)
        {
            case "add":
                result = fn + ln;
                await Context.Response.WriteAsync($"{result}");
                break;
            case "subtract":
                result = fn - ln;
                await Context.Response.WriteAsync($"{result}");
                break;
            case "multiply":
                result = fn * ln;
                await Context.Response.WriteAsync($"{result}");
                break;
            case "divide":
                result = fn / ln;
                await Context.Response.WriteAsync($"{result}");
                break;
            case "modulus":
                result = fn % ln;
                await Context.Response.WriteAsync($"{result}");
                break;
            default:
                Context.Response.StatusCode = 400;
                await Context.Response.WriteAsync("Invalid input for 'operation'\n");
                break;
        }

    }
    else
    {
        await Context.Response.WriteAsync("Invalid input for 'operation'\n");
    }
}
);

app.Run();
