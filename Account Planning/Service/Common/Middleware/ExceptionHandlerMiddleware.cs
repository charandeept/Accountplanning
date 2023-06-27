using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace Com.ACSCorp.AccountPlanning.Service.API
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            context.Response.ContentType = "application/json";
            int statusCode;
            switch (exception)
            {
                case ApplicationException e:
                    // custom application error
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    // not found error
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnauthorizedAccessException e:
                    // unauthorized access error
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                default:
                    // unhandled error
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonConvert.SerializeObject(new
            {
                StatusCode = statusCode,
                ErrorMessage = exception.Message,
            });
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
