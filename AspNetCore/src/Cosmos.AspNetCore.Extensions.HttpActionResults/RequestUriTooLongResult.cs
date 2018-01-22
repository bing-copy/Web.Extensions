using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="RequestUriTooLongResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status414RequestUriTooLong"/> response.
    /// </summary>
    public class RequestUriTooLongResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestUriTooLongResult"/> class.
        /// </summary>
        public RequestUriTooLongResult() : base(StatusCodes.Status414RequestUriTooLong) { }
    }
}
