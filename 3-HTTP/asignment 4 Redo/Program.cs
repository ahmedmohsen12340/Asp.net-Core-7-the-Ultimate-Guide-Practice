using Microsoft.AspNetCore.Http;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.Run(async (context) =>
        {
            int first=int.MinValue;
            int second=int.MinValue;
            string operation="";
            if (context.Request.Query.ContainsKey("firstNumber"))
            {
                int.TryParse(context.Request.Query["firstNumber"],out first);
            }
            if ( context.Request.Query.ContainsKey("secondNumber"))
            {
                int.TryParse(context.Request.Query["secondNumber"], out second);
            }
            if (context.Request.Query.ContainsKey("operation"))
            {
                operation = context.Request.Query["operation"];
            }
            if(first==int.MinValue && second==int.MinValue &&(operation!= "add" || operation != "subtract" || operation != "multiply" || operation != "division" || operation != "modulus"))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
                await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
                await context.Response.WriteAsync("Invalid input for 'operation'\n");
            }
            else if(second == int.MinValue && (operation != "add" || operation != "subtract" || operation != "multiply" || operation != "division" || operation != "modulus"))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
                await context.Response.WriteAsync("Invalid input for 'operation'\n");
            }
            else if (first == int.MinValue && (operation != "add" || operation != "subtract" || operation != "multiply" || operation != "division" || operation != "modulus"))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
                await context.Response.WriteAsync("Invalid input for 'operation'\n");
            }
            else if (!(operation == "add" || operation == "subtract" || operation == "multiply" || operation == "division" || operation == "modulus"))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'operation'\n");
            }
            switch (operation)
            {
                case "add":
                    await context.Response.WriteAsync($"{first+second}");
                    break;
                case "subtract":
                    await context.Response.WriteAsync($"{first - second}");
                    break;
                case "multiply":
                    await context.Response.WriteAsync($"{first * second}");
                    break;
                case "division":
                    await context.Response.WriteAsync($"{first / second}");
                    break;
                case "modulus":
                    await context.Response.WriteAsync($"{first % second}");
                    break;
            }
        });

        app.Run();
    }
}