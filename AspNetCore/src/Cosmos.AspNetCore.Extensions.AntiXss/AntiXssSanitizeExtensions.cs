using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// AntiXss Sanitizer extensions
    /// </summary>
    public static class AntiXssSanitizeExtensions
    {
        /// <summary>
        /// Set the origin html string safty
        /// </summary>
        /// <param name="originHtmlString"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static string ToSafeHtmlString(this string originHtmlString, HttpContext ctx)
            => AntiXssSanitizer.Sanitize(originHtmlString, ctx);

        /// <summary>
        /// Set the origin html string safty
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="originHtmlString"></param>
        /// <returns></returns>
        public static string ToSafeHtmlString(this HttpContext ctx, string originHtmlString)
            => AntiXssSanitizer.Sanitize(originHtmlString, ctx);

        /// <summary>
        /// Set the origin html string safty
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="originHtmlString"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public static string ToSafeHtmlString(this HttpContext ctx, string originHtmlString, string policyName)
            => AntiXssSanitizer.Sanitize(originHtmlString, policyName, ctx);

        /// <summary>
        /// Sanitize source html
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static HtmlString Sanitize(this IHtmlHelper self, string source)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var antiXss = self.ViewContext.HttpContext.RequestServices.GetService(typeof(AntiXss)) as AntiXss;

            if (antiXss == null)
            {
                throw new ArgumentNullException(nameof(antiXss));
            }

            return new HtmlString(antiXss.Sanitize(source));
        }

        /// <summary>
        /// Sanitize source html string
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static HtmlString Sanitize(this IHtmlHelper self, HtmlString source)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self));
            }
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var antiXss = self.ViewContext.HttpContext.RequestServices.GetService(typeof(AntiXss)) as AntiXss;

            if (antiXss == null)
            {
                throw new ArgumentNullException(nameof(antiXss));
            }

            return new HtmlString(antiXss.Sanitize(source.ToString()));
        }
    }
}
