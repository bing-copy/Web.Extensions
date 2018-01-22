using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;

/*
 * 本代码根据 Mocrosoft.AspNetCore.Cors 改写
 * https://github.com/aspnet/CORS/blob/dev/src/Microsoft.AspNetCore.Cors/Infrastructure/CorsMiddleware.cs
 * */

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// Cors filter attribute
    /// </summary>
    public class CorsAttribute : ActionFilterAttribute
    {
        private CorsPolicy _policy;
        private string _policyName;

        /// <summary>
        /// Cors attribute
        /// </summary>
        public CorsAttribute()
        {
            _policyName = InternalCorsPolicyManager.DefaultPolicyName;
        }

        /// <summary>
        /// Cors attribute
        /// </summary>
        /// <param name="policyName"></param>
        public CorsAttribute(string policyName)
        {
            if (string.IsNullOrWhiteSpace(policyName))
            {
                throw new ArgumentNullException(nameof(policyName));
            }

            _policyName = policyName;
        }

        /// <summary>
        /// Cors attribute
        /// </summary>
        /// <param name="policy"></param>
        public CorsAttribute(CorsPolicy policy)
        {
            _policy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        /// <summary>
        /// on action executing...
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HasOrigin(filterContext))
            {
                var corsPolicy = _policy ?? InternalCorsPolicyManager.GetPolicy(_policyName) ?? InternalCorsPolicyManager.GetDefaultPolicy();
                var context = filterContext.RequestContext.HttpContext;
                if (corsPolicy != null &&
                    (!CorsCoreHelper.DoesPolicyContainsMatchingRule(corsPolicy) ||
                    (CorsCoreHelper.DoesPolicyContainsMatchingRule(corsPolicy) && CorsCoreHelper.IsMatchedIgnoreRule(context, corsPolicy))))
                {
                    var corsResult = CorsCoreHelper.EvaluatePolicy(context, corsPolicy);
                    CorsCoreHelper.ApplyResult(corsResult, context.Response);

                    var accessControlRequestMethod = context.Request.Headers[CorsConstants.AccessControlRequestMethod];
                    if (string.Equals(context.Request.HttpMethod, CorsConstants.PreflightHttpMethod, StringComparison.OrdinalIgnoreCase) &&
                        !string.IsNullOrEmpty(accessControlRequestMethod))
                    {
                        context.Response.StatusCode = new HttpStatusCodeResult(HttpStatusCode.NoContent).StatusCode;
                        return;
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
        
        private static bool HasOrigin(ControllerContext filterContext)
            => filterContext.RequestContext.HttpContext.Request.Headers.AllKeys.Contains(CorsConstants.Origin);

    }
}
