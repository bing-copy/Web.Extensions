using Cosmos.AspNetCore.Extensions.Internal;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// Options for alipay browser only middleware
    /// </summary>
    public class AlipayBrowserOnlyOptions
    {
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; } = AlipayConstants.AlipayBrowserOnly;

        /// <summary>
        /// 302 跳转目标
        /// </summary>
        public string RedirectUrl { get; set; }
    }
}
