using System.Threading.Tasks;
using Cosmos.AspNetCore.Extensions.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="MethodNotAllowedResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status405MethodNotAllowed"/> response.
    /// </summary>
    public class MethodNotAllowedResult : StatusCodeResult
    {
        private string _allowedMethods;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodNotAllowedResult"/> class.
        /// </summary>
        public MethodNotAllowedResult(string allowedMethods) : base(StatusCodes.Status405MethodNotAllowed) => AllowedMethods = allowedMethods;

        /// <summary>
        /// Gets or sets the value to put in the response <see cref="HeaderNames.Allow"/> header.
        /// </summary>
        public string AllowedMethods
        {
            get => _allowedMethods;
            set => _allowedMethods = CheckHelper.SetterCheckingWhetherArgumentNullOrNot(value);
        }

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Allow, new StringValues(AllowedMethods));

            return base.ExecuteResultAsync(context);
        }
    }
}
