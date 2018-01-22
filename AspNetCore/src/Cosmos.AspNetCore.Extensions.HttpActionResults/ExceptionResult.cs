using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos.AspNetCore.Extensions
{
    /// <summary>
    /// A <see cref="ExceptionResult"/> that when executed will produce a
    /// <see cref="StatusCodes.Status500InternalServerError"/> response.
    /// </summary>
    public class ExceptionResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionResult"/> class.
        /// </summary>
        /// <param name="exception">The exception to include in the error.</param>
        /// <param name="includeErrorDetail">
        /// <see langword="true"/> if the error should include exception messages; otherwise, <see langword="false"/>.
        /// </param>
        public ExceptionResult(Exception exception, bool includeErrorDetail) : base(exception)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
            StatusCode = StatusCodes.Status500InternalServerError;

            if (includeErrorDetail)
            {
                Value = exception;
            }
            else
            {
                Value = exception.Message;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionResult"/> class.
        /// </summary>
        /// <param name="exception">The exception to include in the error.</param>
        public ExceptionResult(Exception exception) : this(exception, false) { }

        /// <summary>
        /// Gets the exception to include in the error.
        /// </summary>
        public Exception Exception { get; }
    }
}
