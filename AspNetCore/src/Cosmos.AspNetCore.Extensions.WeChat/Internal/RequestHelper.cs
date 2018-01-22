using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace Cosmos.AspNetCore.Extensions.Internal
{
    internal static class RequestHelper
    {
        private static string GetUserAgent(HttpRequest request) => request.Headers[WeChatConstants.UserAgent].FirstOrDefault();

        private static readonly Regex RegexRule = new Regex(WeChatConstants.WeChatBrowserIdentity, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static bool IsWeChatBrowser(HttpRequest request)
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
