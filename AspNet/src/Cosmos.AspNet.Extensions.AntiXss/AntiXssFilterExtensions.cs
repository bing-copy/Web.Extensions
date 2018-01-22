using System;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// AntiXss Extensions
    /// </summary>
    public static class AntiXssFilterExtensions
    {
        /// <summary>
        /// 全局使用 AntiXss
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static GlobalFilterCollection AddAntiXssFilter(this GlobalFilterCollection filters)
        {
            return AddAntiXssFilter(filters, null);
        }

        /// <summary>
        /// 全局使用 AntiXss
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static GlobalFilterCollection AddAntiXssFilter(this GlobalFilterCollection filters, Action<AntiXssOptions> optionsAction)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            var options = new AntiXssOptions();
            optionsAction?.Invoke(options);

            Internal.AntiXssCoreHelper.Init(options);

            return filters;
        }
    }
}
