using Enjin.SDK.Models;
using Refit;

namespace Enjin.SDK
{
    [Headers("Content-Type: application/json")]
    internal interface IProjectService : IAuth, IGetOne<Project>
    {
    }
}