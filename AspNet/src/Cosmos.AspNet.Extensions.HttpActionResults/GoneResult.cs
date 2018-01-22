using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{

    /// <summary>
    /// A <see cref="GoneResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.Gone"/> response.
    /// </summary>
    public class GoneResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectationFailedResult"/> class.
        /// </summary>
        public GoneResult() : base(HttpStatusCode.Gone) { }
    }
}
