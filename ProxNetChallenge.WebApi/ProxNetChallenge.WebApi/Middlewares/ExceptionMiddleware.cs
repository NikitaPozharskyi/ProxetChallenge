using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Serilog;

namespace ProxNetChallenge.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware ( RequestDelegate next )
        {
            _next = next;
        }

        public async Task InvokeAsync ( HttpContext context )
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync ( HttpContext context, Exception exception )
        {
            var httpStatusCode = (int)HttpStatusCode.InternalServerError;
            string message = null;

            Log.Error(exception, @" Unhandled Exception");

            var reasonPhrase = ReasonPhrases.GetReasonPhrase(httpStatusCode);
            var text = $"Status code:{httpStatusCode};{message ?? reasonPhrase}";

            context.Response.ContentType = "text/plain";
            context.Response.StatusCode = httpStatusCode;
            await context.Response.WriteAsync(text);
        }
    }
}
