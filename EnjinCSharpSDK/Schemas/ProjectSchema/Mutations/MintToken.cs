using System.Collections.Generic;
using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class MintToken<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        public T TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public T Mints(List<MintInput> mints)
        {
            return SetVariable("mints", mints);
        }
    }

    [PublicAPI]
    public class MintToken : MintToken<MintToken>
    {
    }

    [PublicAPI]
    public class MintInput
    {
        [JsonProperty("to")]
        private string _to;
        [JsonProperty("value")]
        private string _value;

        public MintInput To(string ethAddress)
        {
            _to = ethAddress;
            return this;
        }

        public MintInput Value(string value)
        {
            _value = value;
            return this;
        }
    }
}