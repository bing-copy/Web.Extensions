﻿using System;

namespace Cosmos.Nancy.Extensions.Internal
{
    internal static class UriHelpers
    {
        public static bool IsSubdomainOf(Uri subdomain, Uri domain)
        {
            return subdomain.IsAbsoluteUri
                   && domain.IsAbsoluteUri
                   && subdomain.Scheme == domain.Scheme
                   && subdomain.Port == domain.Port
                   && subdomain.Host.EndsWith($".{domain.Host}", StringComparison.Ordinal);
        }
    }
}
