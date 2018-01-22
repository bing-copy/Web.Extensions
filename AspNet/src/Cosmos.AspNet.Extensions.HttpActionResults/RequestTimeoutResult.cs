using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="RequestTimeoutResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.RequestTimeout"/> response.
    /// </summary>
    public class RequestTimeoutResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTimeoutResult"/> class.
        /// </summary>
        public RequestTimeoutResult() : base(HttpStatusCode.RequestTimeout) { }
    }
}
