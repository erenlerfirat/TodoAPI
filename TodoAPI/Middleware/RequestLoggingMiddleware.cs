using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate next;        
        private readonly ILogger<RequestLoggingMiddleware> logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var reqBody = context.Request.Body.ToString();
            var reqMethod = context.Request.Method.ToString();
            logger.LogInformation(reqBody,reqMethod);
            await next(context);
        }
        
    }
}
