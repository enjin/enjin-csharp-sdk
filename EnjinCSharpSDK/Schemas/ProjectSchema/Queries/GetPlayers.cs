using System.Collections.Generic;
using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class GetPlayers<T> : PaginationRequest<T>, IPlayerFragmentArguments<T> where T : PaginationRequest<T>, new()
    {
        public T Filter(PlayerFilter filter)
        {
            return SetVariable("filter", filter);
        }
    }

    [PublicAPI]
    public class GetPlayers : GetPlayers<GetPlayers>
    {
    }

    [PublicAPI]
    public class PlayerFilter
    {
        private string _id;
        private List<string> _idIn;
        private List<PlayerFilter> _and;
        private List<PlayerFilter> _or;

        public PlayerFilter Id(string id)
        {
            _id = id;
            return this;
        }

        public PlayerFilter IdIn(List<string> ids)
        {
            _idIn = ids;
            return this;
        }

        public PlayerFilter And(List<PlayerFilter> others)
        {
            _and = others;
            return this;
        }
        
        public PlayerFilter Or(List<PlayerFilter> others)
        {
            _or = others;
            return this;
        }
    }
}