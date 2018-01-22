using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/*
 * 本代码根据 Mocrosoft.AspNetCore.Cors 改写
 * https://github.com/aspnet/CORS/blob/dev/src/Microsoft.AspNetCore.Cors/Infrastructure/CorsService.cs
 * */

namespace Cosmos.AspNet.Extensions.Internal
{
    internal static class CorsCoreHelper
    {
        private static CorsOptions _options;

        public static void Init(CorsOptions options)
        {
            _options = options;
            InternalCorsPolicyManager.SetPolicyMap(options);
        }

        public static bool DoesPolicyContainsMatchingRule(CorsPolicy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            if (!string.IsNullOrWhiteSpace(policy.MatchedKey) && !string.IsNullOrWhiteSpace(policy.MatchedValue))
            {
                return true;
            }

            return false;
        }

        public static bool IsMatchedIgnoreRule(HttpContextBase context, CorsPolicy policy)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            if (string.IsNullOrWhiteSpace(policy.MatchedKey))
            {
                return false;
            }

            if (string.Equals(context.Request.QueryString[policy.MatchedValue], policy.MatchedValue, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(policy.MatchedValue))
            {
                return true;
            }

            return false;
        }

        public static CorsResult EvaluatePolicy(HttpContextBase context, string policyName)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var policy = _options.GetPolicy(policyName);
            return EvaluatePolicy(context, policy);
        }

        public static CorsResult EvaluatePolicy(HttpContextBase context, CorsPolicy policy)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            var corsResult = new CorsResult();
            var accessControlRequestMethod = context.Request.Headers[CorsConstants.AccessControlRequestMethod];
            if (string.Equals(context.Request.HttpMethod, CorsConstants.PreflightHttpMethod, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrEmpty(accessControlRequestMethod))
            {
                EvaluatePreflightRequest(context, policy, corsResult);
            }
            else
            {
                EvaluateRequest(context, policy, corsResult);
            }

            return corsResult;
        }

        public static void EvaluateRequest(HttpContextBase ctx, CorsPolicy policy, CorsResult result)
        {
            var origin = ctx.Request.Headers[CorsConstants.Origin];
            if (!IsOriginAllowed(policy, origin))
            {
                return;
            }

            AddOriginToResult(origin, policy, result);
            result.SupportsCredentials = policy.SupportCredentials;
            AddHeaderValues(result.AllowedExposedHeaders, policy.ExposeHeaders);
        }

        public static void EvaluatePreflightRequest(HttpContextBase ctx, CorsPolicy policy, CorsResult result)
        {
            var origin = ctx.Request.Headers[CorsConstants.Origin];
            if (!IsOriginAllowed(policy, origin))
            {
                return;
            }

            var accessControlRequestMethod = ctx.Request.Headers[CorsConstants.AccessControlRequestMethod];
            if (string.IsNullOrEmpty(accessControlRequestMethod))
            {
                return;
            }

            var requestHeaders = ctx.Request.Headers.GetValues(CorsConstants.AccessControlRequestHeaders);

            if (!policy.AllowAnyMethod)
            {
                var found = false;
                for (var i = 0; i < policy.Methods.Count; i++)
                {
                    var method = policy.Methods[i];
                    if (string.Equals(method, accessControlRequestMethod, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    //policy failure
                    //method not allow
                    return;
                }
            }

            if (!policy.AllowAnyHeader && requestHeaders != null)
            {
                foreach (var requestHeader in requestHeaders)
                {
                    if (!CorsConstants.SimpleRequestHeaders.Contains(requestHeader, StringComparer.OrdinalIgnoreCase) &&
                        !policy.Headers.Contains(requestHeader, StringComparer.OrdinalIgnoreCase))
                    {
                        //policy failure
                        //headers not allow
                        return;
                    }
                }
            }

            AddOriginToResult(origin, policy, result);
            result.SupportsCredentials = policy.SupportCredentials;
            result.PreflightMaxAge = policy.PreflightMaxAge;
            result.AllowedMethods.Add(accessControlRequestMethod);
            AddHeaderValues(result.AllowedHeaders, requestHeaders);

        }

        public static void ApplyResult(CorsResult result, HttpResponseBase response)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var headers = response.Headers;

            if (result.AllowedOrigin != null)
            {
                headers[CorsConstants.AccessControlAllowOrigin] = result.AllowedOrigin;
            }

            if (result.VaryByOrigin)
            {
                headers["Vary"] = "Origin";
            }

            if (result.SupportsCredentials)
            {
                headers[CorsConstants.AccessControlAllowCredentials] = "true";
            }

            if (result.AllowedMethods.Count > 0)
            {
                // Filter out simple methods
                var nonSimpleAllowMethods = result.AllowedMethods
                    .Where(m =>
                        !CorsConstants.SimpleMethods.Contains(m, StringComparer.OrdinalIgnoreCase))
                    .ToArray();

                if (nonSimpleAllowMethods.Length > 0)
                {
                    headers.SetCommaSeparatedValues(
                        CorsConstants.AccessControlAllowMethods,
                        nonSimpleAllowMethods);
                }
            }


            if (result.AllowedHeaders.Count > 0)
            {
                // Filter out simple request headers
                var nonSimpleAllowRequestHeaders = result.AllowedHeaders
                    .Where(header =>
                        !CorsConstants.SimpleRequestHeaders.Contains(header, StringComparer.OrdinalIgnoreCase))
                    .ToArray();

                if (nonSimpleAllowRequestHeaders.Length > 0)
                {
                    headers.SetCommaSeparatedValues(
                        CorsConstants.AccessControlAllowHeaders,
                        nonSimpleAllowRequestHeaders);
                }
            }

            if (result.AllowedExposedHeaders.Count > 0)
            {
                // Filter out simple response headers
                var nonSimpleAllowResponseHeaders = result.AllowedExposedHeaders
                    .Where(header =>
                        !CorsConstants.SimpleResponseHeaders.Contains(header, StringComparer.OrdinalIgnoreCase))
                    .ToArray();

                if (nonSimpleAllowResponseHeaders.Length > 0)
                {
                    headers.SetCommaSeparatedValues(
                        CorsConstants.AccessControlExposeHeaders,
                        nonSimpleAllowResponseHeaders);
                }
            }

            if (result.PreflightMaxAge.HasValue)
            {
                headers[CorsConstants.AccessControlMaxAge]
                    = result.PreflightMaxAge.Value.TotalSeconds.ToString(CultureInfo.InvariantCulture);
            }
        }

        private static void AddOriginToResult(string origin, CorsPolicy policy, CorsResult result)
        {
            if (policy.AllowAnyOrigin)
            {
                if (policy.SupportCredentials)
                {
                    result.AllowedOrigin = origin;
                    result.VaryByOrigin = true;
                }
                else
                {
                    result.AllowedOrigin = CorsConstants.AnyOrigin;
                }
            }
            else if (policy.IsOriginAllowed(origin))
            {
                result.AllowedOrigin = origin;
                if (policy.Origins.Count > 1)
                {
                    result.VaryByOrigin = true;
                }
            }
        }

        public static void AddHeaderValues(IList<string> target, IEnumerable<string> headerValues)
        {
            if (headerValues == null)
            {
                return;
            }

            foreach (var item in headerValues)
            {
                target.Add(item);
            }
        }

        private static bool IsOriginAllowed(CorsPolicy policy, string origin)
        {
            if (string.IsNullOrEmpty(origin))
            {
                //does not have origin header
                return false;
            }

            if (policy.AllowAnyOrigin || policy.IsOriginAllowed(origin))
            {
                return true;
            }

            //policy failure
            //origin not allowed
            return false;
        }
    }
}
