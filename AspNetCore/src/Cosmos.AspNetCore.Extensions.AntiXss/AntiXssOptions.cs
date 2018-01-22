using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// Safe html string options
    /// </summary>
    public class AntiXssOptions
    {
        private string _defaultPolicyName = "__DefaultAntiXssPolicy";

        private IDictionary<string, AntiXssPolicy> PolicyMap { get; } = new ConcurrentDictionary<string, AntiXssPolicy>();

        /// <summary>
        /// Gets or sets default policy name
        /// </summary>
        public string DefaultPolicyName
        {
            get => _defaultPolicyName;
            set => _defaultPolicyName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// add policy
        /// </summary>
        /// <param name="name"></param>
        /// <param name="policy"></param>
        public void AddPolicy(string name, AntiXssPolicy policy)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            PolicyMap[name] = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        /// <summary>
        /// add policy
        /// </summary>
        /// <param name="name"></param>
        /// <param name="configurePolicy"></param>
        public void AddPolicy(string name, Action<AntiXssPolicyBuilder> configurePolicy)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (configurePolicy == null)
            {
                throw new ArgumentNullException(nameof(configurePolicy));
            }

            var policyBuilder = new AntiXssPolicyBuilder();
            configurePolicy(policyBuilder);
            PolicyMap[name] = policyBuilder.Build();
        }

        /// <summary>
        /// Get ploicy by PolicyName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AntiXssPolicy GetPolicy(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return PolicyMap.ContainsKey(name) ? PolicyMap[name] : null;
        }
    }
}
