namespace Practice.Middleware.RequestCounter
{
    public static class RequestCounterExtensions
    {
        public static IApplicationBuilder UseRequestCounter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestHandlerMiddleware>();
        }
    }
}