using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="ImATeapotResult"/> that when executed will produce an
    /// HttpStatusCode 418 response.
    /// </summary>
    public class ImATeapotResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImATeapotResult"/> class.
        /// </summary>
        public ImATeapotResult() : base(418) { }
    }
}
