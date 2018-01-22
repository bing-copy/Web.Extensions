using System;
using System.Collections.Specialized;
using System.Linq;

namespace Cosmos.AspNet.Extensions.Internal
{
    internal static class HeaderDictionaryExtensions
    {
        public static string[] GetCommaSeparatedValues(this NameValueCollection coll, string key)
        {
            if (coll == null)
            {
                throw new ArgumentNullException(nameof(coll));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return coll.AllKeys.Contains(key) ? coll.GetValues(key) : null;
        }

        public static void SetCommaSeparatedValues(this NameValueCollection coll, string key, params string[] values)
        {
            if (coll == null)
            {
                throw new ArgumentNullException(nameof(coll));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (coll.AllKeys.Contains(key))
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
