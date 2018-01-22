using System;
using System.Collections.Generic;

namespace Cosmos.AspNet.Extensions.Internal
{
    internal static class InternalCorsPolicyManager
    {
        private static readonly Dictionary<string, CorsPolicy> _policyMap;
        private static string _defaultPolicyName;

        static InternalCorsPolicyManager()
        {
            _policyMap = new Dictionary<string, CorsPolicy>();
        }

        /// <summary>
        /// 由 CorsCoreHelper 负责初始化
        /// </summary>
        /// <param name="options"></param>
        public static void SetPolicyMap(CorsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var map = options.GetPolicyMap();
            _defaultPolicyName = options.DefaultPolicyName;

            foreach (var key in map.Keys)
            {
                var builder = new CorsPolicyBuilder(map[key]);
                _policyMap.Add(key, builder.Build());
            }

            if (!IsContainsPolicy(_defaultPolicyName))
            {
                _policyMap.Add(_defaultPolicyName, CorsPolicy.DefaultCorsPolicy);
            }

            EnableGlobalCors = options.EnableGlobalCors;
            GlobalCorsPolicyName = string.IsNullOrWhiteSpace(options.GlobalCorsPolicyName)
                ? options.DefaultPolicyName
                : options.GlobalCorsPolicyName;
        }

        public static bool EnableGlobalCors { get; set; } = false;

        public static string GlobalCorsPolicyName { get; set; } = _defaultPolicyName;

        public static string DefaultPolicyName => _defaultPolicyName;

        public static bool IsContainsPolicy(string name) => !string.IsNullOrWhiteSpace(name) && _policyMap.ContainsKey(name);

        public static CorsPolicy GetPolicy(string name) => IsContainsPolicy(name) ? _policyMap[name] : null;

        public static CorsPolicy GetDefaultPolicy() => IsContainsPolicy(_defaultPolicyName) ? _policyMap[_defaultPolicyName] : CorsPolicy.DefaultCorsPolicy;
    }
}
