using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="LengthRequiredResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.LengthRequired"/> response.
    /// </summary>
    public class LengthRequiredResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LengthRequiredResult"/> class.
        /// </summary>
        public LengthRequiredResult() : base(HttpStatusCode.LengthRequired) { }
    }
}
