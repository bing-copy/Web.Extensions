using System;
using Cosmos.AspNet.Extensions.Internal;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// AntiXSS Sanitizer
    /// </summary>
    public static class AntiXssSanitizer
    {
        /// <summary>
        /// Sanitize origin html string
        /// </summary>
        /// <param name="originHtmlString"></param>
        /// <returns></returns>
        public static string Sanitize(string originHtmlString)
        {
            return Sanitize(originHtmlString, InternalAntiXssManager.DefaultPolicyName);
        }

        /// <summary>
        /// Sanitize origin html string
        /// </summary>
        /// <param name="originHtmlString"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public static string Sanitize(string originHtmlString, string policyName)
        {
            if (string.IsNullOrWhiteSpace(originHtmlString))
            {
                throw new ArgumentNullException(nameof(originHtmlString));
            }

            var policy = InternalAntiXssManager.GetPolicy(policyName) ?? InternalAntiXssManager.GetDefaultPolicy();

            return Sanitize(originHtmlString, policy);
        }

        /// <summary>
        /// Sanitize origin html string
        /// </summary>
        /// <param name="originHtmlString"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public static string Sanitize(string originHtmlString, AntiXssPolicy policy)
        {
            if (string.IsNullOrWhiteSpace(originHtmlString))
            {
                throw new ArgumentNullException(nameof(originHtmlString));
            }

            var sanitizer = AntiXssCoreHelper.GetSanitizer(policy);

            return sanitizer.Sanitize(originHtmlString, policy.BaseUrl, policy.OutputFormatter);
        }
    }
}
