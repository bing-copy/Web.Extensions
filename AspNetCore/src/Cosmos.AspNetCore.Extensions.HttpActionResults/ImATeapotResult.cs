using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="ImATeapotResult"/> that when executed will produce an
    /// <see cref="StatusCodes.Status418ImATeapot"/> response.
    /// </summary>
    public class ImATeapotResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImATeapotResult"/> class.
        /// </summary>
        public ImATeapotResult() : base(StatusCodes.Status418ImATeapot) { }
    }
}
