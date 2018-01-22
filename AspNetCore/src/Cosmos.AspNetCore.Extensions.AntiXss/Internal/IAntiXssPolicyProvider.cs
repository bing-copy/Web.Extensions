namespace Cosmos.AspNetCore.Extensions.Internal
{
    /// <summary>
    /// Interface of Antixss policy provider
    /// </summary>
    public interface IAntiXssPolicyProvider
    {
        /// <summary>
        /// Get an antixss policy
        /// </summary>
        /// <param name="policyName"></param>
        /// <returns></returns>
        AntiXssPolicy GetPolicy(string policyName);

        /// <summary>
        /// Get default antixss policy
        /// </summary>
        /// <returns></returns>
        AntiXssPolicy GetDefaultPolicy();
    }
}
