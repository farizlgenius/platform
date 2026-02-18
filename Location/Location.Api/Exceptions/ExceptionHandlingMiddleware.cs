
using Location.Application.Entities;
using Location.Domain.Constants;
using System.Net;
using System.Text.Json;

namespace Location.Api.Exceptions
{
    public sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {

            try
            {
                await next(httpContext);

            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }


        private Task HandleException(HttpContext context, Exception ex)
        {

            List<string> errors = new List<string>();
            errors.Add(ex.Message);
            context.Response.StatusCode = ex is TimeoutException ? (int)HttpStatusCode.RequestTimeout : (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(JsonSerializer.Serialize(new Response<object>()
            {
                Timestamp = DateTime.UtcNow,
                Code = ex is TimeoutException ? HttpStatusCode.RequestTimeout : ex is ArgumentException ? HttpStatusCode.BadRequest : HttpStatusCode.InternalServerError,
                Data = null,
                Message = ex is TimeoutException ? ResponseMessage.REQUEST_TIMEOUT : ex is ArgumentException ? ResponseMessage.BAD_REQUEST : ResponseMessage.INTERNAL_ERROR,
                Details = errors
            }));
        }
    }
}
