using System.Net;
using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// An <see cref="UseProxyResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.UseProxy"/> response.
    /// </summary>  
    public class UseProxyResult : HttpStatusCodeResult
    {
        private string _proxyUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="UseProxyResult"/> class.
        /// </summary>
        /// <param name="proxyUri">A proxy through which the requested resource must be accessed.</param>
        public UseProxyResult(string proxyUri) : base(HttpStatusCode.UseProxy) => ProxyUri = proxyUri;

        /// <summary>
        /// A proxy through which the requested resource must be accessed.
        /// </summary>
        public string ProxyUri
        {
            get => _proxyUri;
            set => _proxyUri = CheckHelper.SetterCheckingWhetherArgumentOutOfRangeOrNot(value);
        }

        /// <inheritdoc />
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Location, ProxyUri);

            base.ExecuteResult(context);
        }
    }
}
