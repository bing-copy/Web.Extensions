using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="PreconditionFailedResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.PreconditionFailed"/> response.
    /// </summary>
    public class PreconditionFailedResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreconditionFailedResult"/> class.
        /// </summary>
        public PreconditionFailedResult() : base(HttpStatusCode.PreconditionFailed) { }
    }
}
