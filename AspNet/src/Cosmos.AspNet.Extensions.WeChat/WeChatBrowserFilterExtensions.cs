using System;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// WeChat browser only extensions
    /// </summary>
    public static class WeChatBrowserFilterExtensions
    {
        /// <summary>
        /// 全局使用 WeChat Browser Only 过滤器
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static GlobalFilterCollection AddWeChatBrowserFilter(this GlobalFilterCollection filters)
        {
            return AddWeChatBrowserFilter(filters, null);
        }

        /// <summary>
        /// 全局使用 WeChat Browser Only 过滤器
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static GlobalFilterCollection AddWeChatBrowserFilter(this GlobalFilterCollection filters, Action<WeChatBrowserOnlyOptions> optionsAction)
        {
            var options = new WeChatBrowserOnlyOptions();
            optionsAction?.Invoke(options);

            filters.Add(Internal.WeChatBrowserOnlyAttributeFactory.Create(options));

            return filters;
        }
    }
}
