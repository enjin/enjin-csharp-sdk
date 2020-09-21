using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Class for sending requests shared across schemas.
    /// </summary>
    public class SharedSchema : BaseSchema, ISharedSchema
    {
        internal readonly IProjectService ProjectService;
        internal readonly IBalanceService BalanceService;
        internal readonly IPlatformService PlatformService;
        internal readonly IRequestService RequestService;
        internal readonly ITokenService TokenService;
        
        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <param name="schema">The schema.</param>
        protected SharedSchema(TrustedPlatformMiddleware middleware, string schema) : base(middleware, schema)
        {
            ProjectService = CreateService<IProjectService>();
            BalanceService = CreateService<IBalanceService>();
            PlatformService = CreateService<IPlatformService>();
            RequestService = CreateService<IRequestService>();
            TokenService = CreateService<ITokenService>();
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Balance>>> GetBalances(GetBalances request)
        {
            return SendRequest(BalanceService.GetMany(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<GasPrices>> GetGasPrices(GetGasPrices request)
        {
            return SendRequest(PlatformService.GetGasPrices(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Platform>> GetPlatform(GetPlatform request)
        {
            return SendRequest(PlatformService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Project>> GetProject(GetProject request)
        {
            return SendRequest(ProjectService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> GetRequest(GetRequest request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Request>>> GetRequests(GetRequests request)
        {
            return SendRequest(RequestService.GetMany(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Token>> GetToken(GetToken request)
        {
            return SendRequest(TokenService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Token>>> GetTokens(GetTokens request)
        {
            return SendRequest(TokenService.GetMany(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> AdvancedSendToken(AdvancedSendToken request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> ApproveEnj(ApproveEnj request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> ApproveMaxEnj(ApproveMaxEnj request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> CompleteTrade(CompleteTrade request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> CreateTrade(CreateTrade request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> MeltToken(MeltToken request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> Message(Message request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> ResetEnjApproval(ResetEnjApproval request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SendEnj(SendEnj request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SendToken(SendToken request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetApprovalForAll(SetApprovalForAll request)
        {
            return TransactionRequest(request);
        }

        /// <summary>
        /// Helper method for sending transaction requests.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        protected Task<GraphqlResponse<Request>> TransactionRequest(IGraphqlRequest request)
        {
            return SendRequest(RequestService.GetOne(Schema, CreateRequestBody(request)));
        }
    }
}