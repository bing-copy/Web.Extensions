using System.Threading.Tasks;
using Cosmos.AspNetCore.Extensions.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="RequestEntityTooLargeResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status413RequestEntityTooLarge"/> response.
    /// </summary>
    public class RequestEntityTooLargeResult : StatusCodeResult
    {
        private string _retryAfter;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestEntityTooLargeResult"/> class.
        /// </summary>
        public RequestEntityTooLargeResult() : base(StatusCodes.Status413RequestEntityTooLarge) { }

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
        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (!string.IsNullOrWhiteSpace(RetryAfter))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.RetryAfter, new StringValues(RetryAfter));
            }

            return base.ExecuteResultAsync(context);
        }
    }
}
