using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="ExpectationFailedResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.ExpectationFailed"/> response.
    /// </summary>
    public class ExpectationFailedResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectationFailedResult"/> class.
        /// </summary>
        public ExpectationFailedResult() : base(HttpStatusCode.ExpectationFailed) { }
    }
}
