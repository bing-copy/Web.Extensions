using System;
using System.Linq;
using AngleSharp;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// AntiXss Policy Builder
    /// </summary>
    public class AntiXssPolicyBuilder
    {
        private readonly AntiXssPolicy _policy = new AntiXssPolicy();

        /// <summary>
        /// Creates a new instance of the <see cref="AntiXssPolicyBuilder"/>.
        /// </summary>
        public AntiXssPolicyBuilder() { }

        /// <summary>
        /// Creates a new instance of the <see cref="AntiXssPolicyBuilder"/>.
        /// </summary>
        /// <param name="policy">The policy which will be used to intialize the builder.</param>
        public AntiXssPolicyBuilder(AntiXssPolicy policy)
        {
            Combine(policy);
        }

        /// <summary>
        /// Adds the specified <paramref name="tags"/> to the policy.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns>The current policy builder.</returns>
        public AntiXssPolicyBuilder WithTags(params string[] tags)
        {
            foreach (var req in tags)
            {
                _policy.AllowedTags.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Adds the specified <paramref name="schemes"/> to the policy.
        /// </summary>
        /// <param name="schemes"></param>
        /// <returns>The current policy builder.</returns>
        public AntiXssPolicyBuilder WithSchemes(params string[] schemes)
        {
            foreach (var req in schemes)
            {
                _policy.AllowedSchemes.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Adds the specified <paramref name="attributes"/> to the policy.
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns>The current policy builder.</returns>
        public AntiXssPolicyBuilder WithAttributes(params string[] attributes)
        {
            foreach (var req in attributes)
            {
                _policy.AllowedAttributes.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Adds the specified <paramref name="attributes"/> to the policy.
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns>The current policy builder.</returns>
        public AntiXssPolicyBuilder WithUriAttributes(params string[] attributes)
        {
            foreach (var req in attributes)
            {
                _policy.UriAttributes.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Adds the specified <paramref name="properties"/> to the policy.
        /// </summary>
        /// <param name="properties"></param>
        /// <returns>The current policy builder.</returns>
        public AntiXssPolicyBuilder WithCssProperties(params string[] properties)
        {
            foreach (var req in properties)
            {
                _policy.AllowedCssProperties.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Adds the specified <paramref name="url"/> to the policy.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>The current policy builder.</returns>
        public AntiXssPolicyBuilder WithBaseUrl(string url)
        {
            _policy.BaseUrl = url;

            return this;
        }

        /// <summary>
        /// Adds the specified <paramref name="formatter"/> to the policy.
        /// </summary>
        /// <param name="formatter"></param>
        /// <returns>The current policy builder.</returns>
        public AntiXssPolicyBuilder WithOutputFormatter(IMarkupFormatter formatter)
        {
            _policy.OutputFormatter = formatter;

            return this;
        }

        /// <summary>
        /// The values of keys in uri need to sanitize.
        /// </summary>
        public AntiXssPolicyBuilder WithUriQueryKeys(params string[] keys)
        {
            foreach (var req in keys)
            {
                _policy.UriQueryKeys.Add(req);
            }

            return this;
        }

        /// <summary>
        /// Build cors-policy
        /// </summary>
        /// <returns></returns>
        public AntiXssPolicy Build()
        {
            return _policy;
        }

        private AntiXssPolicyBuilder Combine(AntiXssPolicy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            WithTags(policy.AllowedTags.ToArray());
            WithSchemes(policy.AllowedSchemes.ToArray());
            WithAttributes(policy.AllowedAttributes.ToArray());
            WithUriAttributes(policy.UriAttributes.ToArray());
            WithCssProperties(policy.AllowedCssProperties.ToArray());
            WithBaseUrl(policy.BaseUrl);
            WithOutputFormatter(policy.OutputFormatter);
            WithUriQueryKeys(policy.UriQueryKeys.ToArray());

            return this;
        }
    }
}
