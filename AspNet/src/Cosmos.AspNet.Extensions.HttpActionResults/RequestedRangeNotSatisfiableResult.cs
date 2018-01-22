using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="RequestedRangeNotSatisfiableResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.RequestedRangeNotSatisfiable"/> response.
    /// </summary>
    public class RequestedRangeNotSatisfiableResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestedRangeNotSatisfiableResult"/> class.
        /// </summary>
        public RequestedRangeNotSatisfiableResult() : base(HttpStatusCode.RequestedRangeNotSatisfiable) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestedRangeNotSatisfiableResult"/> class.
        /// </summary>
        /// <param name="selectedResourceLength"></param>
        public RequestedRangeNotSatisfiableResult(long? selectedResourceLength) : this() => SelectedResourceLength = selectedResourceLength;

        /// <summary>
        /// Gets or sets the current length of the selected resource.
        /// </summary>
        public long? SelectedResourceLength { get; set; }

        /// <inheritdoc />
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.HttpContext.Response.Headers.AllKeys.Contains(HeaderNames.ContentType) &&
                context.HttpContext.Response.Headers[HeaderNames.ContentType] == "multipart/byteranges")
            {
                throw new OperationCanceledException("This response MUST NOT use the multipart/byteranges content-type.");
            }

            if (SelectedResourceLength.HasValue)
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.ContentRange, SelectedResourceLength.ToString());
            }

            base.ExecuteResult(context);
        }
    }
}
