using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="ExpectationFailedResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status417ExpectationFailed"/> response.
    /// </summary>
    public class ExpectationFailedResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectationFailedResult"/> class.
        /// </summary>
        public ExpectationFailedResult() : base(StatusCodes.Status417ExpectationFailed) { }
    }
}
