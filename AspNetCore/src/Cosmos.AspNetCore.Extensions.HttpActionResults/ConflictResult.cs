using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="ConflictResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status409Conflict"/> response.
    /// </summary>
    public class ConflictResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult"/> class.
        /// </summary>
        public ConflictResult() : base(StatusCodes.Status409Conflict) { }
    }
}
