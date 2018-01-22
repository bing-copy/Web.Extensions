using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// 唯支付宝浏览器可访问
    /// </summary>
    public class AlipayBrowserOnlyAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; } = AlipayConstants.AlipayBrowserOnly;

        /// <summary>
        /// 302 跳转目标
        /// </summary>
        public string RedirectUrl { get; set; } = string.Empty;

        private string UserAgent { get; set; }
        private static readonly Regex RegexRule = new Regex(AlipayConstants.AlipayBrowserIdentity, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// when action is executing...
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            UserAgent = filterContext.HttpContext.Request.UserAgent;

            if (!string.IsNullOrWhiteSpace(UserAgent) && RegexRule.IsMatch(UserAgent))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(RedirectUrl))
            {
                filterContext.Result = new RedirectResult(RedirectUrl);
                return;
            }

            filterContext.Result = new ContentResult()
            {
                Content = Message
            };
        }
    }
}
