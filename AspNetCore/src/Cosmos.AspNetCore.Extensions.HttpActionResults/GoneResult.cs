using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="GoneResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status410Gone"/> response.
    /// </summary>
    public class GoneResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoneResult"/> class.
        /// </summary>
        public GoneResult() : base(StatusCodes.Status410Gone) { }
    }
}
