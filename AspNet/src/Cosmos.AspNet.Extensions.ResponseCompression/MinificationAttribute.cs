using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;

namespace Cosmos.AspNet.Extensions {
    public class MinificationAttribute : ActionFilterAttribute {
        /// <summary>
        /// action executing...
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (RequestHelper.IsTextHtml(filterContext.HttpContext.Request)) {
                var response = filterContext.HttpContext.Response;

                var originStream = response.Filter;
                var buffer = originStream.ToArray();
                var compresedData = MinifyHelper.Compress(buffer);
                originStream.Write(compresedData, 0, compresedData.Length);

                response.Filter = originStream;
            }
        }
    }
}