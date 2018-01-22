using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// Response XFrame-Options Middleware
    /// </summary>
    public class ResponseFrameOptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ResponseFrameOptionsType _type;
        private readonly string _domain;

        /// <summary>
        /// Response XFrame-Options Middleware
        /// </summary>
        /// <param name="next"></param>
        /// <param name="type"></param>
        /// <param name="domain"></param>
        public ResponseFrameOptionsMiddleware(RequestDelegate next, ResponseFrameOptionsType type, string domain)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _type = type;
            _domain = domain;
        }

        /// <summary>
        /// Invoke Response XFrame-Options Middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            await _next(context);

            Internal.ResponseHelper.UpdateHeader(context, _type, _domain);
        }
    }
}
