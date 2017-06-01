using System.Collections.Generic;

namespace Cosmos.Nancy.Extensions
{
    public partial class CorsOptions
    {
        internal bool HasDefaultPocily()
        {
            return PolicyMap.ContainsKey(_defaultPolicyName);
        }

        internal IDictionary<string, CorsPolicy> GetPolicyMap() => PolicyMap;
    }
}
