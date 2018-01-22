using System.Net;
using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="RequestEntityTooLargeResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.RequestEntityTooLarge"/> response.
    /// </summary>
    public class RequestEntityTooLargeResult : HttpStatusCodeResult
    {
        private string _retryAfter;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestEntityTooLargeResult"/> class.
        /// </summary>
        public RequestEntityTooLargeResult() : base(HttpStatusCode.RequestEntityTooLarge) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestEntityTooLargeResult"/> class.
        /// </summary>
        /// <param name="retryAfter">The time after which the client may try the request again.</param>
        public RequestEntityTooLargeResult(string retryAfter) : this() => RetryAfter = retryAfter;

        /// <summary>
        /// Gets or sets the the time after which the client may try the request again.
        /// </summary>
        public string RetryAfter
        {
            get => _retryAfter;

            set => _retryAfter = CheckHelper.SetterCheckingWhetherArgumentNullOrNot(value);
        }

        /// <inheritdoc />
        public override void ExecuteResult(ControllerContext context)
        {
            if (!string.IsNullOrWhiteSpace(RetryAfter))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.RetryAfter, RetryAfter);
            }

            base.ExecuteResult(context);
        }
    }
}
