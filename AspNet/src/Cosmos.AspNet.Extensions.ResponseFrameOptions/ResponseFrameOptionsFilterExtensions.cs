using System;
using System.Web;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// Response XFrame-Options extensions
    /// </summary>
    public static class ResponseFrameOptionsFilterExtensions
    {
        /// <summary>
        /// 全局使用 XFrame-Options
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static GlobalFilterCollection AddResponseFrameOptionsFilter(this GlobalFilterCollection filters)
        {
            return AddResponseFrameOptionsFilter(filters, ResponseFrameOptionsType.DENY, string.Empty);
        }

        /// <summary>
        /// 全局使用 XFrame-Options
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static GlobalFilterCollection AddResponseFrameOptionsFilter(this GlobalFilterCollection filters, ResponseFrameOptionsType type)
        {
            return AddResponseFrameOptionsFilter(filters, type, string.Empty);
        }

        /// <summary>
        /// 全局使用 XFrame-Options
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="type"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static GlobalFilterCollection AddResponseFrameOptionsFilter(this GlobalFilterCollection filters, ResponseFrameOptionsType type, string domain)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            filters.Add(new FrameOptionsAttribute { Domain = domain, FrameOptions = type });

            return filters;
        }
    }
}
