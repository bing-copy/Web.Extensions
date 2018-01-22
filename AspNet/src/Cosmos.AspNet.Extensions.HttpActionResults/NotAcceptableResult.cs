using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="NotAcceptableResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.NotAcceptable"/> response.
    /// </summary>
    public class NotAcceptableResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotAcceptableResult"/> class.
        /// </summary>
        public NotAcceptableResult() : base(HttpStatusCode.NotAcceptable) { }
    }
}
