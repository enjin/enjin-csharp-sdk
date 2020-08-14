using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;

namespace Enjin.SDK.Shared
{
    public class SharedSchema : BaseSchema, ISharedSchema
    {
        internal readonly IProjectService ProjectService;
        
        protected SharedSchema(TrustedPlatformMiddleware middleware, string schema) : base(middleware, schema)
        {
            ProjectService = CreateService<IProjectService>();
        }

        public Task<GraphqlResponse<Project>> GetProject(GetProject request)
        {
            return SendRequest(ProjectService.GetOne(Schema, CreateRequestBody(request)));
        }
    }
}