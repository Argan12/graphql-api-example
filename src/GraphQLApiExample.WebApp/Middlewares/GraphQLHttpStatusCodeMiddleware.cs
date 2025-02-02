using GraphQLApiExample.Application;

namespace GraphQLApiExample.WebApp.Middlewares
{
    public class GraphQLHttpStatusCodeMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        private readonly Dictionary<string, int>  ErrorMapping = new()
        {
            { Constants.VALIDATION_ERRORS, StatusCodes.Status400BadRequest },
            { Constants.BAD_REQUEST, StatusCodes.Status400BadRequest },
            { Constants.RESOURCE_NOT_FOUND, StatusCodes.Status404NotFound }
        };

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var responseJson = await new StreamReader(memoryStream).ReadToEndAsync();

            MapErrorToHttpStatusCode(context, responseJson);

            memoryStream.Seek(0, SeekOrigin.Begin);

            await memoryStream.CopyToAsync(originalBodyStream);
        }

        private void MapErrorToHttpStatusCode(HttpContext context, string responseJson)
        {
            var statusCode = ErrorMapping.FirstOrDefault(entry => responseJson.Contains(entry.Key)).Value;

            if (statusCode != 0)
            {
                context.Response.StatusCode = statusCode;
            }
        }
    }
}