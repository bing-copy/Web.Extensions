using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// Response XFrame-Options Attribute
    /// </summary>
    public class FrameOptionsAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// XFrame-Options Type
        /// </summary>
        public ResponseFrameOptionsType FrameOptions { get; set; } = ResponseFrameOptionsType.DENY;

        /// <summary>
        /// Domain
        /// </summary>
        public string Domain { get; set; } = string.Empty;

        /// <summary>
        /// On result executed
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Internal.ResponseHelper.UpdateHeader(filterContext.HttpContext.Response, FrameOptions, Domain);
        }
    }
}
