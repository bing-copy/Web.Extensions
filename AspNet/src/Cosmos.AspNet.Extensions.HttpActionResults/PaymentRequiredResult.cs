using System.Net;
using System.Web.Mvc;

namespace Cosmos.AspNet.Extensions
{
    /// <summary>
    /// A <see cref="PaymentRequiredResult"/> that when executed will produce an empty
    /// <see cref="HttpStatusCode.PaymentRequired"/> response.
    /// </summary>
    public class PaymentRequiredResult : HttpStatusCodeResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRequiredResult"/> class.
        /// </summary>
        public PaymentRequiredResult() : base(HttpStatusCode.PaymentRequired) { }
    }
}
