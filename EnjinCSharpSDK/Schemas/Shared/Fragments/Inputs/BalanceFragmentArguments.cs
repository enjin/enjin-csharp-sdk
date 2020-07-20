using System.Runtime.Serialization;
using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface IBalanceFragmentArguments<out T> : IVariableHolder<T>
    {
    }
    
    [PublicAPI]
    public static class BalanceFragmentArguments
    {
        public static T BalIdFormat<T>(this T instance, TokenIdFormat balIdFormat) where T : IVariableHolder<T>
        {
            return instance.SetVariable("balIdFormat", balIdFormat);
        }
        
        public static T BalIndexFormat<T>(this T instance, TokenIndexFormat balIndexFormat) where T : IVariableHolder<T>
        {
            return instance.SetVariable("balIndexFormat", balIndexFormat);
        }
        
        public static T WithBalProjectId<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withBalAppId", true);
        }
        
        public static T WithBalWalletAddress<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withBalWalletAddress", true);
        }
    }

    [PublicAPI]
    public enum TokenIdFormat
    {
        [EnumMember(Value = "hex64")]
        HEX64,
        [EnumMember(Value = "hex256")]
        HEX256,
        [EnumMember(Value = "uint256")]
        UINT256
    }

    [PublicAPI]
    public enum TokenIndexFormat
    {
        [EnumMember(Value = "hex64")]
        HEX64,
        [EnumMember(Value = "uint64")]
        UINT64
    }
}