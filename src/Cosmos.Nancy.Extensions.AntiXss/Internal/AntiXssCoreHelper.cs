using System;
using System.Dynamic;
using Ganss.XSS;
using Nancy;

namespace Cosmos.Nancy.Extensions.Internal
{
    internal static class AntiXssCoreHelper
    {
        internal static void DoAntiXssForRequest(NancyContext ctx)
        {
            if (!InternalAntiXssManager.HasInit)
            {
                throw new ArgumentException("The internal anti-xss manager has not been initialized.");
            }

            dynamic ret = new ExpandoObject();
            var qs = ctx.Request.Query;
            var policy = InternalAntiXssManager.GetDefaultPolicy();
            var sanitizer = GetSanitizer(policy);
            foreach (var key in policy.UriQueryKeys)
            {
                try
                {
                    qs[key] = sanitizer.Sanitize(qs[key]);
                }
                catch
                {
                    // ignored
                }
            }
        }


        internal static HtmlSanitizer GetSanitizer(AntiXssPolicy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            return new HtmlSanitizer(policy.AllowedTags, policy.AllowedSchemes, policy.AllowedAttributes, policy.UriAttributes, policy.AllowedCssProperties);
        }
    }
}
