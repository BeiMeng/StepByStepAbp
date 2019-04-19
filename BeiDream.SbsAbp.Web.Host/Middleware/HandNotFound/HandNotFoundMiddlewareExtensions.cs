using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Web.Middleware.HandNotFound
{
    public static class HandNotFoundMiddlewareExtensions
    {
        public static IApplicationBuilder UseHandNotFoundMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandNotFoundMiddleware>();
        }
    }
}
