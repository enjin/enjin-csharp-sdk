using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting an asset's whitelist.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetWhitelisted : GraphqlRequest<SetWhitelisted>, IProjectTransactionRequestArguments<SetWhitelisted>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetWhitelisted() : base("enjin.sdk.project.SetWhitelisted")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetWhitelisted AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the account address to be added to the whitelist.
        /// </summary>
        /// <param name="accountAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public SetWhitelisted AccountAddress(string? accountAddress)
        {
            return SetVariable("accountAddress", accountAddress);
        }
        
        /// <summary>
        /// Sets the whitelisted setting for the account.
        /// </summary>
        /// <param name="whitelisted">The setting.</param>
        /// <returns>This request for chaining.</returns>
        public SetWhitelisted Whitelisted(Whitelisted? whitelisted)
        {
            return SetVariable("whitelisted", whitelisted);
        }
        
        /// <summary>
        /// Sets the specified address for sending or receiving.
        /// </summary>
        /// <param name="whitelistedAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public SetWhitelisted WhitelistedAddress(string? whitelistedAddress)
        {
            return SetVariable("whitelistedAddress", whitelistedAddress);
        }
        
        /// <summary>
        /// Sets whether the whitelist setting is on or off.
        /// </summary>
        /// <param name="on">The setting.</param>
        /// <returns>This request for chaining.</returns>
        public SetWhitelisted On(bool? on)
        {
            return SetVariable("on", on);
        }
    }
}