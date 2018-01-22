using System;
using Cosmos.AspNetCore.Extensions.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// AntiXss sanitizer
    /// </summary>
    public static class AntiXssSanitizer
    {
        /// <summary>
        /// Sanitize origin html string
        /// </summary>
        /// <param name="originHtmlString"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static string Sanitize(string originHtmlString, HttpContext ctx)
        {
            if (ctx == null)
            {
                throw new ArgumentNullException(nameof(ctx));
            }

            if (string.IsNullOrWhiteSpace(originHtmlString))
            {
                throw new ArgumentNullException(nameof(originHtmlString));
            }

            var antiXss = ctx.RequestServices.GetRequiredService<AntiXss>();

            if (antiXss == null)
            {
                throw new ArgumentNullException(nameof(antiXss));
            }

            return Sanitizer(originHtmlString, antiXss);
        }

        /// <summary>
        /// Sanitize origin html string
        /// </summary>
        /// <param name="originHtmlString"></param>
        /// <param name="policyName"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static string Sanitize(string originHtmlString, string policyName, HttpContext ctx)
        {
            if (ctx == null)
            {
                throw new ArgumentNullException(nameof(ctx));
            }

            if (string.IsNullOrWhiteSpace(originHtmlString))
            {
                throw new ArgumentNullException(nameof(originHtmlString));
            }

            if (string.IsNullOrWhiteSpace(policyName))
            {
                throw new ArgumentNullException(nameof(policyName));
            }

            var antiXss = ctx.RequestServices.GetRequiredService<AntiXss>();
            var antiXssPolicyProvider = ctx.RequestServices.GetRequiredService<IAntiXssPolicyProvider>();

            if (antiXss == null)
            {
                throw new ArgumentNullException(nameof(antiXss));
            }

            var policy = antiXssPolicyProvider.GetPolicy(policyName) ?? antiXssPolicyProvider.GetDefaultPolicy();

            return Sanitizer(originHtmlString, antiXss, policy);
        }


        private static string Sanitizer(string originHtmlString, AntiXss antiXss, AntiXssPolicy policy = null)
        {
            return policy == null ? antiXss.Sanitize(originHtmlString) : antiXss.Sanitize(originHtmlString, policy);
        }
    }
}
