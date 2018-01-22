using System.Net;
using System.Web.Mvc;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// An <see cref="ServiceUnavailableResult"/> that when executed will produce a
    /// <see cref="HttpStatusCode.ServiceUnavailable"/> response.
    /// </summary>
    public class ServiceUnavailableResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableResult"/> class.
        /// </summary>
        public ServiceUnavailableResult() : base(HttpStatusCode.ServiceUnavailable) { }

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
        public override void ExecuteResult(ControllerContext context)
        {
            if (!string.IsNullOrWhiteSpace(LengthOfDelay))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.RetryAfter, LengthOfDelay);
            }

            base.ExecuteResult(context);
        }
    }
}
