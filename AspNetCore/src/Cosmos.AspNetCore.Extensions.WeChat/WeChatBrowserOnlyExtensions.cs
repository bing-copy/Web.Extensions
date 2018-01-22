using System;
using Cosmos.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// WeChat browser oly extensions
    /// </summary>
    public static class WeChatBrowserOnlyExtensions
    {
        /// <summary>
        /// Use wechat browser only middleware
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseWeChatBrowserOnly(this IApplicationBuilder app)
        {
            return UseWeChatBrowserOnly(app, null);
        }

        /// <summary>
        /// Use wechat browser only middleware
        /// </summary>
        /// <param name="app"></param>
        /// <param name="optionAction"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseWeChatBrowserOnly(this IApplicationBuilder app, Action<WeChatBrowserOnlyOptions> optionAction)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new WeChatBrowserOnlyOptions();
            optionAction?.Invoke(options);

            app.UseMiddleware<WeChatBrowserOnlyMiddleware>(options);

            return app;
        }
    }
}
