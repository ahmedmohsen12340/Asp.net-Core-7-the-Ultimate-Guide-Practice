namespace middleWareTraining.MiddleWares
{
    public class MiddleWareClass : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello MW2\n");
            await next(context);
            await context.Response.WriteAsync("MW2 again\n");

        }
    }
    public static class MiddleWareExtention
    {
        public static IApplicationBuilder myMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MiddleWareClass>();
        }
    }
}
