using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="ServiceUnavailableResult"/> that when executed will produce a
    /// <see cref="StatusCodes.Status503ServiceUnavailable"/> response.
    /// </summary>
    public class ServiceUnavailableResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableResult"/> class.
        /// </summary>
        public ServiceUnavailableResult() : base(StatusCodes.Status503ServiceUnavailable) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableResult"/> class.
        /// </summary>
        /// <param name="lengthOfDelay">Length of delay to put in the response header.</param>
        public ServiceUnavailableResult(string lengthOfDelay) : this() => LengthOfDelay = lengthOfDelay;

        /// <summary>
        /// Gets or sets the length of the delay to put in the response header.
        /// </summary>
        public string LengthOfDelay { get; set; }

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (!string.IsNullOrWhiteSpace(LengthOfDelay))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.RetryAfter, new StringValues(LengthOfDelay));
            }

            return base.ExecuteResultAsync(context);
        }
    }
}
