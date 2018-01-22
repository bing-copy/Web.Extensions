using System;
using Cosmos.AspNetCore.Extensions.Internal;
using Ganss.XSS;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// AntiXss opt entity
    /// </summary>
    public class AntiXss
    {
        private IAntiXssPolicyProvider __provider;

        /// <summary>
        /// AntiXss opt entity
        /// </summary>
        /// <param name="provider"></param>
        public AntiXss(IAntiXssPolicyProvider provider)
        {
            __provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        /// <summary>
        /// Sanitize source html
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string Sanitize(string source)
        {
            return Sanitize(source, builderAction: null);
        }

        /// <summary>
        /// Sanitize source html
        /// </summary>
        /// <param name="source"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public string Sanitize(string source, string policyName)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (string.IsNullOrWhiteSpace(policyName))
            {
                throw new ArgumentNullException(nameof(policyName));
            }

            var policy = __provider.GetPolicy(policyName);

            return Sanitize(source, policy);
        }

        /// <summary>
        /// Sanitize source html
        /// </summary>
        /// <param name="source"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public string Sanitize(string source, AntiXssPolicy policy)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            var sanitizer = new HtmlSanitizer(policy.AllowedTags, policy.AllowedSchemes, policy.AllowedAttributes, policy.UriAttributes, policy.AllowedCssProperties);

            return sanitizer.Sanitize(source, policy.BaseUrl, policy.OutputFormatter);
        }

        /// <summary>
        /// Sanitize source html
        /// </summary>
        /// <param name="source"></param>
        /// <param name="builderAction"></param>
        /// <returns></returns>
        public string Sanitize(string source, Action<AntiXssPolicyBuilder> builderAction)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            var builder = new AntiXssPolicyBuilder();
            builderAction?.Invoke(builder);
            var policy = builder.Build();

            return Sanitize(source, policy);
        }
    }
}
