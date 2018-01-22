using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// An <see cref="NotModifiedResult"/>  that when executed will produce an empty
    /// <see cref="HttpStatusCode.NotModified"/> response.
    /// </summary>
    public class NotModifiedResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotModifiedResult"/> class.
        /// </summary>
        public NotModifiedResult() : base(HttpStatusCode.NotModified) { }
    }
}
