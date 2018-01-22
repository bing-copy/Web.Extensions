using System;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// Response compression filter extensions
    /// </summary>
    public static class ResponseCompressionFilterExtensions
    {
        /// <summary>
        /// 全局使用 Compression filter
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static GlobalFilterCollection AddResponseCompressionFilter(this GlobalFilterCollection filters)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            filters.Add(new CompressionAttribute());

            return filters;
        }
    }
}
