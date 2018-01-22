using System;
using Cosmos.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Response XFrame-Options extensions
    /// </summary>
    public static class ResponseFrameOptionsExtensions
    {
        /// <summary>
        /// Add Response XFrame-Options
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddResponseFrameOptions(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        /// <summary>
        /// Use Response XFrame-Options Middleware
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseResponseFrameOptions(this IApplicationBuilder app)
        {
            return app.UseResponseFrameOptions(ResponseFrameOptionsType.DENY, string.Empty);
        }

        /// <summary>
        /// Use Response XFrame-Options Middleware
        /// </summary>
        /// <param name="app"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseResponseFrameOptions(this IApplicationBuilder app, ResponseFrameOptionsType type)
        {
            return app.UseResponseFrameOptions(type, string.Empty);
        }

        /// <summary>
        /// Use Response XFrame-Options Middleware
        /// </summary>
        /// <param name="app"></param>
        /// <param name="type"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseResponseFrameOptions(this IApplicationBuilder app, ResponseFrameOptionsType type, string domain)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            app.UseMiddleware<ResponseFrameOptionsMiddleware>(type, domain);

            return app;
        }
    }
}
