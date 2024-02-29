using BooksStore.Data.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Net;
using BooksStore.Data.ViewModels;
using Microsoft.Extensions.Logging;

namespace BooksStore.Exceptions
{
    public static class GlobalExceptionMiddleware
    {

            public static void ConfigureBuiltInGlobalExceptionHandlerExtension(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType= "application/json";

                    //to use in errorviewmodel intializtion'
                    var contextFeatureMsgCollector = context.Features.Get<IExceptionHandlerFeature>();

                    var contextRequestToGetPath = context.Features.Get<IHttpRequestFeature>();


                    //to check msg in app
                    if(contextFeatureMsgCollector != null)
                    {
                        var loggerVmString = new ErrorViewModel() //logger
                        //await context.Response.WriteAsync(
                        //    new ErrorViewModel()
                        //{
                        //        StatusCode = context.Response.StatusCode,
                        //        Message = contextFeatureMsgCollector.Error.Message,
                        //        Path = contextRequestToGetPath.Path
                        //    }.ToString()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeatureMsgCollector.Error.Message,
                            Path = contextRequestToGetPath.Path
                        }.ToString();
                      //  ILogger.LogError(loggerVmString);
                    }
                
                });
            });
        }



          public static void ConfigureCsutomeHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomGlobalHandleException>();
        }
    }
}
