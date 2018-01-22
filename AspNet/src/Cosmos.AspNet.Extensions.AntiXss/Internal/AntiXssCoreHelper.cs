using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;
using Ganss.XSS;

namespace Cosmos.AspNet.Extensions.Internal
{
    internal static class AntiXssCoreHelper
    {
        private static AntiXssOptions _options;

        public static void Init(AntiXssOptions options)
        {
            _options = options;
            InternalAntiXssManager.SetPolicyMap(options);
        }

        public static void ApplyPolicy(string policyName, HttpRequestBase request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var policy = _options.GetPolicy(policyName);

            ApplyPolicy(policy, request);
        }

        public static void ApplyPolicy(AntiXssPolicy policy, HttpRequestBase request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            //RefreshRequestParams(request.Unvalidated.Headers, request.Headers, policy);
            RefreshRequestParams(request.Unvalidated.QueryString, request.QueryString, policy);
            //RefreshRequestParams(request.Unvalidated.Form, request.Form, policy);
        }

        private static void RefreshRequestParams(NameValueCollection unalidatedColl, NameValueCollection coll, AntiXssPolicy policy)
        {
            if (unalidatedColl == null || coll == null || policy == null)
            {
                return;
            }

            var cachedDict = GetSanitizedDict(unalidatedColl, policy);
            SetReturnedRequest(cachedDict, coll);
        }

        private static Dictionary<string, string> GetSanitizedDict(NameValueCollection unalidatedColl, AntiXssPolicy policy)
        {
            if (unalidatedColl == null)
            {
                throw new ArgumentNullException(nameof(unalidatedColl));
            }

            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            var sanitizer = GetSanitizer(policy);
            var ret = new Dictionary<string, string>();
            foreach (var key in unalidatedColl.AllKeys)
            {
                try
                {
                    ret.Add(key, sanitizer.Sanitize(unalidatedColl[key], policy.BaseUrl, policy.OutputFormatter));
                }
                catch
                {
                    ret.Add(key, unalidatedColl[key]);
                }
            }

            return ret;
        }

        private static void SetReturnedRequest(Dictionary<string, string> cachedDict, NameValueCollection coll)
        {
            PropertyInfo readonlyPiHandler = typeof(NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

            if (readonlyPiHandler == null)
            {
                throw new ArgumentNullException(nameof(readonlyPiHandler));
            }

            readonlyPiHandler.SetValue(coll, false, null);

            foreach (var key in cachedDict.Keys)
            {
                coll[key] = cachedDict[key];
            }

            readonlyPiHandler.SetValue(coll, true, null);
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
