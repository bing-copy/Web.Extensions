using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// AntiXss filter Attribute
    /// </summary>
    public class AntiXssAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// on action executing...
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var qs = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(context.HttpContext.Request.QueryString.ToUriComponent());
            var ret = new Microsoft.AspNetCore.Http.QueryString();
            var antiXss = context.HttpContext.RequestServices.GetRequiredService<AntiXss>();
            foreach (var k in qs.Keys)
            {
                for (var i = 0; i < qs[k].Count(); i++)
                {
                    try
                    {
                        ret.Add(k, antiXss.Sanitize(qs[k][i]));
                    }
                    catch
                    {
                        ret.Add(k, qs[k][i]);
                    }
                }
            }
            context.HttpContext.Request.QueryString = ret;
            base.OnActionExecuting(context);
        }
    }
}
