using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// 唯微信浏览器可访问
    /// </summary>
    public class WeChatBrowserOnlyAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; } = WeChatConstants.WeChatBrowserOnly;

        /// <summary>
        /// 302 跳转目标
        /// </summary>
        public string RedirectUrl { get; set; }

        private string UserAgent { get; set; }
        private static readonly Regex RegexRule = new Regex(WeChatConstants.WeChatBrowserIdentity, RegexOptions.IgnoreCase | RegexOptions.Compiled);

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
