using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="InternalServerErrorResult"/> that when executed will produce a
    /// <see cref="StatusCodes.Status500InternalServerError"/> response.
    /// </summary>
    public class InternalServerErrorResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorResult"/> class.
        /// </summary>
        public InternalServerErrorResult() : base(StatusCodes.Status500InternalServerError) { }
    }
}
