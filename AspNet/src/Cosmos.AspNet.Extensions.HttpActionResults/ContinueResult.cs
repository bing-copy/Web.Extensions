using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="ContinueResult"/> that when executed will 
    /// produce a Continue (100) response.
    /// </summary>
    public class ContinueResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult"/> class.
        /// </summary>
        public ContinueResult() : base(HttpStatusCode.Continue) { }
    }
}
