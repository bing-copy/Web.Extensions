using System;

namespace Cosmos.AspNetCore.Extensions.Internal
{
    /// <summary>
    /// AntiXss policy provider
    /// </summary>
    public class AntiXssPolicyProvider : IAntiXssPolicyProvider
    {
        private readonly AntiXssOptions _options;

        /// <summary>
        /// AntiXss policy provider
        /// </summary>
        /// <param name="options"></param>
        public AntiXssPolicyProvider(AntiXssOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Get an antixss policy
        /// </summary>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public AntiXssPolicy GetPolicy(string policyName) => _options.GetPolicy(policyName);

        /// <summary>
        /// Get default antixss policy
        /// </summary>
        /// <returns></returns>
        public AntiXssPolicy GetDefaultPolicy() => _options.GetPolicy(_options.DefaultPolicyName);

    }
}
