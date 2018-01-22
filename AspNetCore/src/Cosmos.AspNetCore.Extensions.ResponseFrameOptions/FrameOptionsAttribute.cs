using Microsoft.AspNetCore.Mvc.Filters;

namespace Cosmos.AspNetCore.Extensions
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
        /// On result executing
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Internal.ResponseHelper.UpdateHeader(context.HttpContext, FrameOptions, Domain);
        }
    }
}
