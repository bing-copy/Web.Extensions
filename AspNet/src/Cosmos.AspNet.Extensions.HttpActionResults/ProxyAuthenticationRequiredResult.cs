using System.Net;
using System.Web.Mvc;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// An <see cref="ProxyAuthenticationRequiredResult"/> that when executed will produce a
    /// <see cref="HttpStatusCode.ProxyAuthenticationRequired"/> response.
    /// </summary>
    public class ProxyAuthenticationRequiredResult : HttpStatusCodeResult
    {
        /// <summary>
        /// An <see cref="HttpStatusCode"/> that when executed will produce a
        /// Initializes a new instance of the <see cref="ProxyAuthenticationRequiredResult"/> class.
        /// </summary>
        /// <param name="proxyAuthenticate">Challenge applicable to the proxy for the requested resource.</param>
        public ProxyAuthenticationRequiredResult(string proxyAuthenticate) : base(HttpStatusCode.ProxyAuthenticationRequired) => ProxyAuthenticate = proxyAuthenticate;

        /// <summary>
        /// Gets or sets a challenge applicable to the proxy for the requested resource
        /// </summary>
        public string ProxyAuthenticate { get; set; }

        /// <inheritdoc />
        public override void ExecuteResult(ControllerContext context)
        {
            if (!string.IsNullOrWhiteSpace(ProxyAuthenticate))
            {
                context.HttpContext.Response.Headers.Add(HeaderNames.ProxyAuthenticate, ProxyAuthenticate);
            }

            base.ExecuteResult(context);
        }
    }
}
