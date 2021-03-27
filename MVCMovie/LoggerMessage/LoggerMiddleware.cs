using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.LoggerMessage
{

    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerMiddleware> _logger;

        public LoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<LoggerMiddleware>() ??
            throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(new EventId(1), $"Request URL [{UriHelper.GetDisplayUrl(context.Request)}]");
            await _next(context);
            _logger.LogInformation(new EventId(1), $"Respons StatusCode [{context.Response.StatusCode}]");

        }
    }

    public static class UseLoggerMiddleware
    {
        public static IApplicationBuilder UseLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggerMiddleware>();
        }
    }
}
