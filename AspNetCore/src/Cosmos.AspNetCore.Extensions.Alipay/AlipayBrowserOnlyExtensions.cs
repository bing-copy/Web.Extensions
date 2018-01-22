using System;
using Cosmos.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Alipay browser oly extensions
    /// </summary>
    public static class AlipayBrowserOnlyExtensions
    {
        /// <summary>
        /// Use alipay browser only middleware
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAlipayBrowserOnly(this IApplicationBuilder app)
        {
            return UseAlipayBrowserOnly(app, null);
        }

        /// <summary>
        /// Use alipay browser only middleware
        /// </summary>
        /// <param name="app"></param>
        /// <param name="optionAction"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAlipayBrowserOnly(this IApplicationBuilder app, Action<AlipayBrowserOnlyOptions> optionAction)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new AlipayBrowserOnlyOptions();
            optionAction?.Invoke(options);

            app.UseMiddleware<AlipayBrowserOnlyMiddleware>(options);

            return app;
        }
    }
}
