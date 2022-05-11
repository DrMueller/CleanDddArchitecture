using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Mmu.CleanDddSimple.CrossCutting.Services.Logging;
using Mmu.CleanDddSimple.Web.Infrastructure.ExceptionHandling.Models;
using Newtonsoft.Json;

namespace Mmu.CleanDddSimple.Web.Infrastructure.ExceptionHandling.Middlewares
{
    [PublicAPI]
    internal class GlobalExceptionHandlingMiddleware
    {
        private readonly ILoggingService _loggingService;
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILoggingService loggingService)
        {
            _next = next;
            _loggingService = loggingService;
        }

        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Global exception handler")]
        [SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "Microsoft-convention for middlewares")]
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                _loggingService.LogException(exception);

                var response = httpContext.Response;
                response.ContentType = MediaTypeNames.Application.Json;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var serverError = UnExpectedServerError.CreateFromException(exception);
                var serializedServerError = JsonConvert.SerializeObject(serverError);

                await response.WriteAsync(serializedServerError);
            }
        }
    }
}