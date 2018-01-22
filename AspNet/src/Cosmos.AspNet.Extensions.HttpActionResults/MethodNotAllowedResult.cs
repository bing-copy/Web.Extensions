using System.Net;
using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="MethodNotAllowedResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.MethodNotAllowed"/> response.
    /// </summary>
    public class MethodNotAllowedResult : HttpStatusCodeResult
    {
        private string _allowedMethods;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodNotAllowedResult"/> class.
        /// </summary>
        public MethodNotAllowedResult(string allowedMethods) : base(HttpStatusCode.MethodNotAllowed) => AllowedMethods = allowedMethods;

        /// <summary>
        /// Gets or sets the value to put in the response <see cref="HeaderNames.Allow"/> header.
        /// </summary>
        public string AllowedMethods
        {
            get => _allowedMethods;
            set => _allowedMethods = CheckHelper.SetterCheckingWhetherArgumentNullOrNot(value);
        }

        /// <inheritdoc />
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Allow, AllowedMethods);

            base.ExecuteResult(context);
        }
    }
}
