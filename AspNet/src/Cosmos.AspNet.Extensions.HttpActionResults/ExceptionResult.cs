using System;
using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="ExceptionResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.InternalServerError"/> response.
    /// </summary>
    public class ExceptionResult : HttpStatusCodeResult
    {
        public ExceptionResult(Exception exception, string explicitMessage)
            : base(HttpStatusCode.InternalServerError, string.IsNullOrWhiteSpace(explicitMessage) ? exception?.Message : explicitMessage)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));

            ExplicitMessage = string.IsNullOrWhiteSpace(explicitMessage)

                ? exception.Message
                : explicitMessage;
        }

        public ExceptionResult(Exception exception) : this(exception, string.Empty) { }

        /// <summary>
        /// Gets the exception to include in the error.
        /// </summary>
        public Exception Exception { get; }

        public string ExplicitMessage { get; }
    }
}
