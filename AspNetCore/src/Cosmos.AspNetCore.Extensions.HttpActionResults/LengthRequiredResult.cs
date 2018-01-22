using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="LengthRequiredResult"/> that when executed will produce an empty
    /// <see cref="StatusCodes.Status411LengthRequired"/> response.
    /// </summary>
    public class LengthRequiredResult : StatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LengthRequiredResult"/> class.
        /// </summary>
        public LengthRequiredResult() : base(StatusCodes.Status411LengthRequired) { }
    }
}
