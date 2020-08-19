using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public interface IProjectSchema : ISharedSchema
    {
        Task<GraphqlResponse<AccessToken>> AuthPlayer(AuthPlayer request);
        
        Task<GraphqlResponse<AccessToken>> AuthProject(AuthProject request);

        Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request);

        Task<GraphqlResponse<List<Player>>> GetPlayers(GetPlayers request);
        
        Task<GraphqlResponse<AccessToken>> CreatePlayer(CreatePlayer request);

        Task<GraphqlResponse<Request>> CreateToken(CreateToken request);
        
        Task<GraphqlResponse<Request>> DecreaseMaxMeltFee(DecreaseMaxMeltFee request);
        
        Task<GraphqlResponse<Request>> DecreaseMaxTransferFee(DecreaseMaxTransferFee request);

        Task<GraphqlResponse<bool>> DeletePlayer(DeletePlayer request);
        
        Task<GraphqlResponse<bool>> InvalidateTokenMetadata(InvalidateTokenMetadata request);
        
        Task<GraphqlResponse<Request>> MintToken(MintToken request);
        
        Task<GraphqlResponse<Request>> ReleaseReserve(ReleaseReserve request);
        
        Task<GraphqlResponse<Request>> SetMeltFee(SetMeltFee request);
        
        Task<GraphqlResponse<Request>> SetTransferable(SetTransferable request);
        
        Task<GraphqlResponse<Request>> SetTransferFee(SetTransferFee request);
        
        Task<GraphqlResponse<Request>> SetUri(SetUri request);
        
        Task<GraphqlResponse<Request>> SetWhitelisted(SetWhitelisted request);
        
        Task<GraphqlResponse<bool>> UnlinkWallet(UnlinkWallet request);
        
        Task<GraphqlResponse<Request>> UpdateName(UpdateName request);
    }
}