using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// AntiXss attribute
    /// </summary>
    public class AntiXssAttribute : ValidateInputAttribute// ActionFilterAttribute
    {
        /// <summary>
        /// AntiXSS attribute
        /// </summary>
        public AntiXssAttribute() : base(false) { }

        /// <summary>
        /// Policy name
        /// </summary>
        public string PolicyName { get; set; }

        /// <summary>
        /// on action executing...
        /// </summary>
        /// <param name="filterContext"></param>
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var request = filterContext.RequestContext.HttpContext.Request;
        //    var policy = InternalAntiXssManager.GetPolicy(PolicyName) ?? InternalAntiXssManager.GetDefaultPolicy();
        //    if (policy != null)
        //    {
        //        AntiXssCoreHelper.ApplyPolicy(policy, request);
        //    }

        //    base.OnActionExecuting(filterContext);
        //}

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var request = filterContext.RequestContext.HttpContext.Request;
            var policy = InternalAntiXssManager.GetPolicy(PolicyName) ?? InternalAntiXssManager.GetDefaultPolicy();
            if (policy != null)
            {
                AntiXssCoreHelper.ApplyPolicy(policy, request);
            }
        }
    }
}
