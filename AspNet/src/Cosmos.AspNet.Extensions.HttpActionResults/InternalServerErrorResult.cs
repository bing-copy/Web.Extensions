using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="InternalServerErrorResult"/> that when executed will produce a
    /// <see cref="HttpStatusCode.InternalServerError"/> response.
    /// </summary>
    public class InternalServerErrorResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorResult"/> class.
        /// </summary>
        public InternalServerErrorResult() : base(HttpStatusCode.InternalServerError) { }
    }
}
