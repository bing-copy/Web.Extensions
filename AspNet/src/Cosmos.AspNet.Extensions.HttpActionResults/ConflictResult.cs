using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="ConflictResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.Conflict"/> response.
    /// </summary>
    public class ConflictResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult"/> class.
        /// </summary>
        public ConflictResult() : base(HttpStatusCode.Conflict) { }
    }
}
