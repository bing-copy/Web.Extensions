using Cosmos.Nancy.Extensions.Internal;
using Nancy;

namespace Cosmos.Nancy.Extensions
{
    /// <summary>
    /// Options for wechat browser only filter
    /// </summary>
    public class WeChatBrowserOnlyOptions
    {
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; } = WeChatConstants.WeChatBrowserOnly;

        /// <summary>
        /// 302 跳转目标
        /// </summary>
        public string RedirectUrl { get; set; } = string.Empty;

        /// <summary>
        /// Http Status Code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
