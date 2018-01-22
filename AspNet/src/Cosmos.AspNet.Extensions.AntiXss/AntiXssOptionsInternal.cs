using System.Collections.Generic;

namespace Cosmos.AspNet.Extensions
{
    public partial class AntiXssOptions
    {
        internal bool HasDefaultPocily()
        {
            return PolicyMap.ContainsKey(_defaultPolicyName);
        }

        internal IDictionary<string, AntiXssPolicy> GetPolicyMap() => PolicyMap;
    }
}
