using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="NotAcceptableResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status406NotAcceptable"/> response.
    /// </summary>
    public class NotAcceptableResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotAcceptableResult"/> class.
        /// </summary>
        public NotAcceptableResult() : base(StatusCodes.Status406NotAcceptable) { }
    }
}
