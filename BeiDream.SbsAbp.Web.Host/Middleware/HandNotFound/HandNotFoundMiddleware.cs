using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Web.Middleware.HandNotFound
{
    public class HandNotFoundMiddleware
    {
        private readonly RequestDelegate _next;
        public HandNotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Response.Redirect("index.html");
            }
            return _next(httpContext);
        }
    }
}
