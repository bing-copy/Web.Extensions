using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="ResetContentResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.ResetContent"/> response.
    /// </summary>
    public class ResetContentResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTimeoutResult"/> class.
        /// </summary>
        public ResetContentResult() : base(HttpStatusCode.ResetContent) { }
    }
}
