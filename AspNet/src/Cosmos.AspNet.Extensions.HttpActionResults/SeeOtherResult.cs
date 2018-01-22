using System.Net;
using System.Web.Mvc;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// An <see cref="SeeOtherResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.SeeOther"/> response.
    /// </summary>
    public class SeeOtherResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeeOtherResult"/> class.
        /// </summary>
        public SeeOtherResult() : base(HttpStatusCode.SeeOther) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeeOtherResult"/> class.
        /// </summary>
        /// <param name="location">Location to put in the response header.</param>
        public SeeOtherResult(string location) : this() => Location = location;

        /// <summary>
        /// Gets or sets the location to put in the response header.
        /// </summary>
        public string Location { get; set; }

        /// <inheritdoc />
        public override void ExecuteResult(ControllerContext context)
        {
            if (!string.IsNullOrWhiteSpace(Location))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.Location, Location);
            }

            base.ExecuteResult(context);
        }
    }
}
