using System;
using Cosmos.AspNetCore.Extensions;
using Cosmos.AspNetCore.Extensions.Internal;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// AntiXss extensions
    /// </summary>
    public static class AntiXssExtension
    {
        /// <summary>
        /// Add AntiXss
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAntiXss(this IServiceCollection services)
        {
            return AddAntiXss(services, null);
        }

        /// <summary>
        /// Add AntiXss
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddAntiXss(this IServiceCollection services, Action<AntiXssOptions> optionsAction)
        {
            var options = new AntiXssOptions();
            optionsAction?.Invoke(options);
            
            // ReSharper disable once RedundantTypeArgumentsOfMethod
            services.AddSingleton<AntiXssOptions>(options);
            services.AddSingleton<IAntiXssPolicyProvider, AntiXssPolicyProvider>();
            
            services.AddTransient<AntiXss>();

            return services;
        }
    }
}
