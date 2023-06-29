namespace Practice.Middleware.RequestCounter
{
    public class RequestHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly RequestCounter counter;

        public RequestHandlerMiddleware(RequestDelegate next, RequestCounter counter)
        {
            this.next = next;
            this.counter = counter;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!counter.CanHandleRequest())
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                return;
            }

            counter.Increment();

            try
            {
                await next.Invoke(context);
            }
            finally
            {
                counter.Decrement();
            }
        }
    }
}
