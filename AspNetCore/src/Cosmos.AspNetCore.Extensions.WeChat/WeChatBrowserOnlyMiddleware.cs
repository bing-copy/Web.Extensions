using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// WeChat Browser Only Middleware
    /// </summary>
    public class WeChatBrowserOnlyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WeChatBrowserOnlyOptions _options;

        /// <summary>
        /// WeChat browser only middleware
        /// </summary>
        /// <param name="next"></param>
        /// <param name="options"></param>
        public WeChatBrowserOnlyMiddleware(RequestDelegate next, WeChatBrowserOnlyOptions options)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Invoke WeChat browser only Middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!Internal.RequestHelper.IsWeChatBrowser(context.Request))
            {
                await Internal.ResponseHelper.DoWeChatBrowserOnlyOption(context, _options);
                return;
            }

            await _next(context);
        }
    }
}
