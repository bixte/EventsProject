namespace EventsProject.MiddleWare
{
    public class ValidationExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        public ValidationExceptionHandlerMiddleware(RequestDelegate next) => this.next = next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(exception.Message);
        }
    }
}
