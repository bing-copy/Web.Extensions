using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="RequestUriTooLongResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.RequestUriTooLong"/> response.
    /// </summary>
    public class RequestUriTooLongResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTimeoutResult"/> class.
        /// </summary>
        public RequestUriTooLongResult() : base(HttpStatusCode.RequestUriTooLong) { }
    }
}
