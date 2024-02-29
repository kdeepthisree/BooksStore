using BooksStore.Data.ViewModels;
using System.Net;

namespace BooksStore.Exceptions
{
    public class CustomGlobalHandleException
    {

        private readonly RequestDelegate _next;


        public CustomGlobalHandleException(RequestDelegate next)
        {
            _next = next;
        }



        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";


            //reconstruction response object
            var response = new ErrorViewModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal server error from custom Middleware",
                Path = "path goes here"
            };


            return context.Response.WriteAsync(response.ToString());
        }
    }
}
