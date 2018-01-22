using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="NotImplementedResult"/> that when executed will produce a
    /// <see cref="HttpStatusCode.NotImplemented"/> response.
    /// </summary>
    public class NotImplementedResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotImplementedResult"/> class.
        /// </summary>
        public NotImplementedResult() : base(HttpStatusCode.NotImplemented) { }
    }
}
