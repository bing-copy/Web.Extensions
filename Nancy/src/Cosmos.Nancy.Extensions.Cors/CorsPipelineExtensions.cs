using System;
using System.Linq;
using Cosmos.Nancy.Extensions.Internal;
using Nancy;

namespace Cosmos.Nancy.Extensions
{
    public static class CorsPipelineExtensions
    {
        public static void WithCors(this NancyContext context)
        {
            WithCors(context, InternalCorsPolicyManager.GetDefaultPolicy());
        }

        public static void WithCors(this NancyContext context, string policyName)
        {
            var policy = InternalCorsPolicyManager.GetPolicy(policyName) ??
                         InternalCorsPolicyManager.GetDefaultPolicy();

            WithCors(context, policy);
        }

        public static void WithCors(this NancyContext context, Action<CorsPolicyBuilder> builderAction)
        {
            var builder = new CorsPolicyBuilder();
            builderAction?.Invoke(builder);

            WithCors(context, builder.Build());
        }

        public static void WithCors(this NancyContext context, CorsPolicy policy)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (policy != null && HasOrigin(context))
            {
                if (!CorsCoreHelper.DoesPolicyContainsMatchingRule(policy) ||
                    CorsCoreHelper.DoesPolicyContainsMatchingRule(policy) && CorsCoreHelper.IsMatchedIgnoreRule(context, policy))
                {
                    var corsResult = CorsCoreHelper.EvaluatePolicy(context, policy);
                    CorsCoreHelper.ApplyResult(corsResult, context.Response);

                    var accessControlRequestMethod = context.Request.Headers[CorsConstants.AccessControlRequestMethod]?.FirstOrDefault();
                    if (string.Equals(context.Request.Method, CorsConstants.PreflightHttpMethod,
                            StringComparison.OrdinalIgnoreCase) &&
                        !string.IsNullOrEmpty(accessControlRequestMethod))
                    {
                        context.Response.StatusCode = HttpStatusCode.NoContent;
                    }
                }
            }

        }

        private static bool HasOrigin(NancyContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.Request.Headers.Keys.Contains(CorsConstants.Origin);
        }
    }
}
