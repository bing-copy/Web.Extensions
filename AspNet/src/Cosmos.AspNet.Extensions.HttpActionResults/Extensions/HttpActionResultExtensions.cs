using System;
using System.Text;
using System.Web.Mvc;

// ReSharper disable once CheckNamespace
namespace Cosmos.AspNet.Extensions
{
    public static class HttpActionResultExtensions
    {
        private static string Combine(string[] strings)
        {
            if (strings.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (var item in strings)
                sb.Append($"{item}, ");
            return sb.ToString(0, sb.Length - 2);
        }

        public static BadGatewayResult BadGateway(this ControllerBase controller) => new BadGatewayResult();
        public static ConflictResult Conflict(this ControllerBase controller) => new ConflictResult();
        public static ContinueResult Continue(this ControllerBase controller) => new ContinueResult();
        public static ExpectationFailedResult ExpectationFailed(this ControllerBase controller) => new ExpectationFailedResult();
        public static GatewayTimeoutResult GatewayTimeout(this ControllerBase controller) => new GatewayTimeoutResult();
        public static GoneResult Gone(this ControllerBase controller) => new GoneResult();
        public static HttpVersionNotSupportedResult HttpVersionNotSupported(this ControllerBase controller) => new HttpVersionNotSupportedResult();
        public static ImATeapotResult ImATeapot(this ControllerBase controller) => new ImATeapotResult();
        public static InternalServerErrorResult InternalServerError(this ControllerBase controller) => new InternalServerErrorResult();
        public static ExceptionResult InternalServerError(this ControllerBase controller, Exception exception) => new ExceptionResult(exception ?? throw new ArgumentNullException(nameof(exception)));
        public static ExceptionResult InternalServerError(this ControllerBase controller, Exception exception, string explicitMessage) => new ExceptionResult(exception ?? throw new ArgumentNullException(nameof(exception)), explicitMessage);
        public static LengthRequiredResult LengthRequired(this ControllerBase controller) => new LengthRequiredResult();
        public static MethodNotAllowedResult MethodNotAllowed(this ControllerBase controller, string allowedMethods) => new MethodNotAllowedResult(allowedMethods);
        public static MethodNotAllowedResult MethodNotAllowed(this ControllerBase controller, params string[] allowedMethods) => new MethodNotAllowedResult(Combine(allowedMethods));
        public static MultipleChoicesResult MultipleChoices(this ControllerBase controller, string preferedChoiceUri = null) => new MultipleChoicesResult(preferedChoiceUri);
        public static NotAcceptableResult NotAcceptable(this ControllerBase controller) => new NotAcceptableResult();
        public static NonAuthoritativeInformationResult NonAuthoritativeInformation(this ControllerBase controller) => new NonAuthoritativeInformationResult();
        public static NotImplementedResult NotImplemented(this ControllerBase controller) => new NotImplementedResult();
        public static NotModifiedResult NotModified(this ControllerBase controller) => new NotModifiedResult();
        public static PartialContentResult PartialContent(this ControllerBase controller) => new PartialContentResult();
        public static PaymentRequiredResult PaymentRequired(this ControllerBase controller) => new PaymentRequiredResult();
        public static PreconditionFailedResult PreconditionFailed(this ControllerBase controller) => new PreconditionFailedResult();
        public static ProxyAuthenticationRequiredResult ProxyAuthenticationRequired(this ControllerBase controller, string proxyAuthenticate) => new ProxyAuthenticationRequiredResult(proxyAuthenticate);
        public static RequestEntityTooLargeResult RequestEntityTooLarge(this ControllerBase controller) => new RequestEntityTooLargeResult();
        public static RequestEntityTooLargeResult RequestEntityTooLarge(this ControllerBase controller, long retryAfter) => new RequestEntityTooLargeResult(retryAfter.ToString());
        public static RequestEntityTooLargeResult RequestEntityTooLarge(this ControllerBase controller, DateTime retryAfter) => new RequestEntityTooLargeResult(retryAfter.ToUniversalTime().ToString("r"));
        public static RequestedRangeNotSatisfiableResult RequestedRangeNotSatisfiable(this ControllerBase controller) => new RequestedRangeNotSatisfiableResult();
        public static RequestedRangeNotSatisfiableResult RequestedRangeNotSatisfiable(this ControllerBase controller, long? selectedResourceLength) => new RequestedRangeNotSatisfiableResult(selectedResourceLength);
        public static RequestTimeoutResult RequestTimeout(this ControllerBase controller) => new RequestTimeoutResult();
        public static RequestUriTooLongResult RequestUriTooLong(this ControllerBase controller) => new RequestUriTooLongResult();
        public static ResetContentResult ResetContent(this ControllerBase controller) => new ResetContentResult();
        public static SeeOtherResult SeeOther(this ControllerBase controller) => new SeeOtherResult();
        public static SeeOtherResult SeeOther(this ControllerBase controller, string uri) => new SeeOtherResult(uri);
        public static ServiceUnavailableResult ServiceUnavailable(this ControllerBase controller) => new ServiceUnavailableResult();
        public static ServiceUnavailableResult ServiceUnavailable(this ControllerBase controller, string lengthOfDelay) => new ServiceUnavailableResult(lengthOfDelay);
        public static SwitchingProtocolsResult SwitchingProtocols(this ControllerBase controller, string upgradeTo) => new SwitchingProtocolsResult(upgradeTo);
        public static TemporaryRedirectResult TemporaryRedirect(this ControllerBase controller, string temporaryUri) => new TemporaryRedirectResult(temporaryUri);
        public static UseProxyResult UseProxy(this ControllerBase controller, string proxyUri) => new UseProxyResult(proxyUri);
    }
}
