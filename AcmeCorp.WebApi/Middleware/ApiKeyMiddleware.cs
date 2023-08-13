namespace AcmeCorp.WebApi.Middleware
{
    // We would typically use an API gateway for this sort of thing...
    // CREDIT: https://github.com/gowthamece/ApiKeyAuthentication
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private
        const string APIKEY = "XApiKey";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Check for API key in request headers...
            if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("An XApiKey Key was not found in the request header");
                return;
            }

            // Putting the key here because you would never do this...
              var apiKey = "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp";
            
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
            await _next(context);
        }
    }
}
