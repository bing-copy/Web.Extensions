﻿using System;
using System.Text.RegularExpressions;
using Nancy;

namespace Cosmos.Nancy.Extensions.Internal
{
    internal static class RequestHelper
    {
        private static string GetUserAgent(Request request) => request.Headers.UserAgent;

        private static readonly Regex RegexRule = new Regex(AlipayConstants.AlipayBrowserIdentity, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static bool IsAlipayBrowser(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var userAgent = GetUserAgent(request);

            return !string.IsNullOrWhiteSpace(userAgent) && RegexRule.IsMatch(userAgent);
        }
    }
}
