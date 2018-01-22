﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// An <see cref="HttpVersionNotSupportedResult"/> that when executed performs content negotiation, formats the entity body, and
    /// will produce a <see cref="StatusCodes.Status505HttpVersionNotsupported"/> response if negotiation and formatting succeed.
    /// </summary>
    public class HttpVersionNotSupportedResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpVersionNotSupportedResult"/> class.
        /// </summary>
        public HttpVersionNotSupportedResult(object value) : base(value) => StatusCode = StatusCodes.Status505HttpVersionNotsupported;
    }
}
