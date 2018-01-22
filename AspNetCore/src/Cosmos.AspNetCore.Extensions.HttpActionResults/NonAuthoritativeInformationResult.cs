using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="NonAuthoritativeInformationResult"/> that when executed will produce a
    /// <see cref="StatusCodes.Status203NonAuthoritative"/> response.
    /// </summary>
    public class NonAuthoritativeInformationResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonAuthoritativeInformationResult"/> class.
        /// </summary>
        public NonAuthoritativeInformationResult() : base(StatusCodes.Status203NonAuthoritative) { }
    }
}
