using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Class for sending requests in the project schema.
    /// </summary>
    [PublicAPI]
    public class ProjectSchema : SharedSchema, IProjectSchema
    {
        private const string SCHEMA = "app";
        
        internal readonly IPlayerService PlayerService;
        
        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        public ProjectSchema(TrustedPlatformMiddleware middleware) : base(middleware, SCHEMA)
        {
            PlayerService = CreateService<IPlayerService>();
        }
        
        /// <inheritdoc/>
        public Task<GraphqlResponse<AccessToken>> AuthPlayer(AuthPlayer request)
        {
            return SendRequest(PlayerService.Auth(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<AccessToken>> AuthProject(AuthProject request)
        {
            return SendRequest(ProjectService.Auth(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request)
        {
            return SendRequest(PlayerService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Player>>> GetPlayers(GetPlayers request)
        {
            return SendRequest(PlayerService.GetMany(Schema, CreateRequestBody(request)));
        }
        
        /// <inheritdoc/>
        public Task<GraphqlResponse<AccessToken>> CreatePlayer(CreatePlayer request)
        {
            return SendRequest(PlayerService.Auth(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> CreateToken(CreateToken request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> DecreaseMaxMeltFee(DecreaseMaxMeltFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> DecreaseMaxTransferFee(DecreaseMaxTransferFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool>> DeletePlayer(DeletePlayer request)
        {
            return SendRequest(PlayerService.Delete(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool>> InvalidateTokenMetadata(InvalidateTokenMetadata request)
        {
            return SendRequest(TokenService.Delete(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> MintToken(MintToken request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> ReleaseReserve(ReleaseReserve request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetMeltFee(SetMeltFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetTransferable(SetTransferable request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetTransferFee(SetTransferFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetUri(SetUri request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetWhitelisted(SetWhitelisted request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool>> UnlinkWallet(UnlinkWallet request)
        {
            return SendRequest(PlayerService.Delete(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> UpdateName(UpdateName request)
        {
            return TransactionRequest(request);
        }
    }
}