using System;
using System.Collections.Generic;

namespace Cosmos.Nancy.Extensions.Internal
{
    internal static class HeaderDictionaryExtensions
    {
        public static void SetCommaSeparatedValues(this IDictionary<string, string> coll, string key, params string[] values)
        {
            if (coll == null)
            {
                throw new ArgumentNullException(nameof(coll));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (coll.Keys.Contains(key))
            {
                coll[key] = string.Join(",", values);
            }
            else
            {
                coll.Add(key, string.Join(",", values));
            }
        }
    }
}
