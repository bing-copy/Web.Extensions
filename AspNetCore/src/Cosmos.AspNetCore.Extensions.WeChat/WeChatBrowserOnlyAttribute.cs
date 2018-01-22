using System;
using Cosmos.AspNetCore.Extensions.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cosmos.AspNetCore.Extensions
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

        /// <summary>
        /// 动作名
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 控制器名
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// when action is executing...
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (RequestHelper.IsWeChatBrowser(context.HttpContext.Request))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(ActionName) && !string.IsNullOrWhiteSpace(ControllerName))
            {
                context.Result = new RedirectToActionResult(ActionName, ControllerName, null);
                return;
            }

            if (!string.IsNullOrWhiteSpace(RedirectUrl))
            {
                context.Result = new RedirectResult(RedirectUrl);
                return;
            }

            context.Result = new ContentResult()
            {
                Content = Message
            };
        }
    }
}
