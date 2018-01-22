using System.Net;
using System.Web.Mvc;
using Cosmos.AspNet.Extensions.Internal;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="SwitchingProtocolsResult"/> that when executed will 
    /// produce a Switching Protocols (101) response.
    /// </summary>
    public class SwitchingProtocolsResult : HttpStatusCodeResult
    {
        private string _upgradeTo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchingProtocolsResult"/> class.
        /// </summary>
        /// <param name="upgradeTo">Value to put in the response "Upgrade" header.</param>
        public SwitchingProtocolsResult(string upgradeTo) : base(HttpStatusCode.SwitchingProtocols) => UpgradeTo = upgradeTo;

        /// <summary>
        /// Gets or sets the value to put in the response Upgrade header.
        /// </summary>
        public string UpgradeTo
        {
            get => _upgradeTo;
            set => _upgradeTo = CheckHelper.SetterCheckingWhetherArgumentNullOrNot(value);
        }

        /// <inheritdoc />
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.Connection, "upgrade");
            context.HttpContext.Response.Headers.Add(HeaderNames.Upgrade, UpgradeTo);

            base.ExecuteResult(context);
        }
    }
}
