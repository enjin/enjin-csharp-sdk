using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface ISharedSchema
    {
        Task<GraphqlResponse<List<Balance>>> GetBalances(GetBalances request);

        Task<GraphqlResponse<GasPrices>> GetGasPrices(GetGasPrices request);

        Task<GraphqlResponse<Platform>> GetPlatform(GetPlatform request);
        
        Task<GraphqlResponse<Project>> GetProject(GetProject request);

        Task<GraphqlResponse<Request>> GetRequest(GetRequest request);

        Task<GraphqlResponse<List<Request>>> GetRequests(GetRequests request);

        Task<GraphqlResponse<Token>> GetToken(GetToken request);

        Task<GraphqlResponse<List<Token>>> GetTokens(GetTokens request);

        Task<GraphqlResponse<Request>> AdvancedSendToken(AdvancedSendToken request);
        
        Task<GraphqlResponse<Request>> ApproveEnj(ApproveEnj request);
        
        Task<GraphqlResponse<Request>> ApproveMaxEnj(ApproveMaxEnj request);
        
        Task<GraphqlResponse<Request>> CompleteTrade(CompleteTrade request);
        
        Task<GraphqlResponse<Request>> CreateTrade(CreateTrade request);
        
        Task<GraphqlResponse<Request>> MeltToken(MeltToken request);
        
        Task<GraphqlResponse<Request>> Message(Message request);
        
        Task<GraphqlResponse<Request>> ResetEnjApproval(ResetEnjApproval request);
        
        Task<GraphqlResponse<Request>> SendEnj(SendEnj request);
        
        Task<GraphqlResponse<Request>> SendToken(SendToken request);
        
        Task<GraphqlResponse<Request>> SetApprovalForAll(SetApprovalForAll request);
    }
}