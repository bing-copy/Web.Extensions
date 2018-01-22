using System;
using System.Linq;

namespace Cosmos.Nancy.Extensions.Internal
{
    internal static class CorsPolicyExtensions
    {
        private const string _WildcardSubdomain = "*";

        public static bool IsOrginAnAllowedSubdomain(this CorsPolicy policy, string origin)
        {
            if (policy.Origins.Contains(origin))
            {
                return true;
            }

            var originUri = new Uri(origin, UriKind.Absolute);
            return policy.Origins
                .Where(o => o.Contains($"://{_WildcardSubdomain}"))
                .Select(CreateDomainUri)
                .Any(domain => UriHelpers.IsSubdomainOf(originUri, domain));
        }


        private static Uri CreateDomainUri(string origin)
            => new Uri(origin.Replace(_WildcardSubdomain, string.Empty), UriKind.Absolute);
    }
}
