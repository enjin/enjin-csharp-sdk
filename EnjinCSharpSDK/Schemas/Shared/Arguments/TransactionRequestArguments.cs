using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface ITransactionRequestArguments<out T> : ITransactionFragmentArguments<T>
    {
    }
    
    [PublicAPI]
    public static class TransactionRequestArguments
    {
        public static T EthAddress<T>(this T instance, string ethAddress) where T : IVariableHolder<T>
        {
            return instance.SetVariable("ethAddress", ethAddress);
        }
        
        public static T Test<T>(this T instance, string test) where T : IVariableHolder<T>
        {
            return instance.SetVariable("test", test);
        }
        
        public static T Send<T>(this T instance, string send) where T : IVariableHolder<T>
        {
            return instance.SetVariable("send", send);
        }
    }
}