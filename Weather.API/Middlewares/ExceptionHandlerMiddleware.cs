using System.Net;

namespace Weather.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger,
            RequestDelegate next)
        {
            this._logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                // Log This Exception
                _logger.LogError(ex, $"{errorId} : {ex.Message}");

                // Return A Custom Exrror Response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! We are looking into resolving this."
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}

