using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cosmos.AspNetCore.Extensions.Internal
{
    internal static class ResponseHelper
    {
        public static async Task DoWeChatBrowserOnlyOption(HttpContext context, WeChatBrowserOnlyOptions options)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (!string.IsNullOrWhiteSpace(options.RedirectUrl))
            {
                context.Response.Redirect(options.RedirectUrl);
                return;
            }

            await context.Response.WriteAsync(options.Message);
        }
    }
}
