﻿using System;
using System.Collections.Generic;

namespace Cosmos.AspNet.Extensions.Internal
{
    internal static class InternalAntiXssManager
    {
        private static readonly Dictionary<string, AntiXssPolicy> _policyMap;
        private static string _defaultPolicyName;

        static InternalAntiXssManager()
        {
            _policyMap = new Dictionary<string, AntiXssPolicy>();
        }

        public static void SetPolicyMap(AntiXssOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var map = options.GetPolicyMap();
            _defaultPolicyName = options.DefaultPolicyName;

            _policyMap.Clear();

            foreach (var key in map.Keys)
            {
                var builder = new AntiXssPolicyBuilder(map[key]);
                _policyMap.Add(key, builder.Build());
            }

            if (!IsContainsPolicy(_defaultPolicyName))
            {
                _policyMap.Add(_defaultPolicyName, AntiXssPolicy.DefaultAntiXssPolicy);
            }
        }

        public static string DefaultPolicyName => _defaultPolicyName;

        public static bool IsContainsPolicy(string name) => string.IsNullOrWhiteSpace(name) ? false : _policyMap.ContainsKey(name);

        public static AntiXssPolicy GetPolicy(string name) => IsContainsPolicy(name) ? _policyMap[name] : null;

        public static AntiXssPolicy GetDefaultPolicy() => IsContainsPolicy(_defaultPolicyName) ? _policyMap[_defaultPolicyName] : AntiXssPolicy.DefaultAntiXssPolicy;
    }
}
