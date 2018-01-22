using System;
using System.Linq;
using Cosmos.Nancy.Extensions.Internal;
using Nancy;
using Nancy.Bootstrapper;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// CORS Configure Extensions
    /// </summary>
    public static class CorsConfigureExtensions
    {
        /// <summary>
        /// Use cors module
        /// </summary>
        /// <param name="pipelines"></param>
        /// <returns></returns>
        public static IPipelines UseCors(this IPipelines pipelines)
        {
            return UseCors(pipelines, null);
        }

        /// <summary>
        /// Use cors module
        /// </summary>
        /// <param name="pipelines"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IPipelines UseCors(this IPipelines pipelines, Action<CorsOptions> optionsAction)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException(nameof(pipelines));
            }

            var options = new CorsOptions();
            optionsAction?.Invoke(options);

            InternalCorsPolicyManager.SetPolicyMap(options);

            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
            {
                if (InternalCorsPolicyManager.EnableGlobalCors /*&& HasOrigin(ctx)*/)
                {
                    var corsPolicy =
                        InternalCorsPolicyManager.GetPolicy(InternalCorsPolicyManager.GlobalCorsPolicyName) ??
                        InternalCorsPolicyManager.GetDefaultPolicy();
                    if (corsPolicy != null &&
                        (!CorsCoreHelper.DoesPolicyContainsMatchingRule(corsPolicy) ||
                         (CorsCoreHelper.DoesPolicyContainsMatchingRule(corsPolicy) && CorsCoreHelper.IsMatchedIgnoreRule(ctx, corsPolicy))))
                    {
                        var corsResult = CorsCoreHelper.EvaluatePolicy(ctx, corsPolicy);
                        CorsCoreHelper.ApplyResult(corsResult, ctx.Response);

                        var accessControlRequestMethod = ctx.Request.Headers[CorsConstants.AccessControlRequestMethod]?.FirstOrDefault();
                        if (string.Equals(ctx.Request.Method, CorsConstants.PreflightHttpMethod, StringComparison.OrdinalIgnoreCase) &&
                            !string.IsNullOrEmpty(accessControlRequestMethod))
                        {
                            ctx.Response.StatusCode = HttpStatusCode.NoContent;
                        }
                    }
                }

                //return null;
            });

            return pipelines;
        }

        private static bool HasOrigin(NancyContext ctx)
        {
            if (ctx == null)
            {
                throw new ArgumentNullException(nameof(ctx));
            }

            return ctx.Request.Headers.Keys.Contains(CorsConstants.Origin);
        }
    }
}
