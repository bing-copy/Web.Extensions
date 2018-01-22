using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// Alipay Browser Only Middleware
    /// </summary>
    public class AlipayBrowserOnlyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AlipayBrowserOnlyOptions _options;

        /// <summary>
        /// Alipay browser only middleware
        /// </summary>
        /// <param name="next"></param>
        /// <param name="options"></param>
        public AlipayBrowserOnlyMiddleware(RequestDelegate next, AlipayBrowserOnlyOptions options)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Invoke Alipay browser only Middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (!Internal.RequestHelper.IsAlipayBrowser(context.Request))
            {
                await Internal.ResponseHelper.DoAlipayBrowserOnlyOption(context, _options);
                return;
            }

            await _next(context);
        }
    }
}
