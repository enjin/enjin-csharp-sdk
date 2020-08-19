using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface ITransactionFragmentArguments<out T> : IVariableHolder<T>
    {
    }
    
    [PublicAPI]
    public static class TransactionFragmentArguments
    {
        public static T WithMeta<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withMeta", true);
        }
        
        public static T WithEncodedData<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withEncodedData", true);
        }
        
        public static T WithTokenData<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withTokenData", true);
        }
        
        public static T WithSignedTxs<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withSignedTxs", true);
        }
        
        public static T WithError<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withError", true);
        }
        
        public static T WithNonce<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withNonce", true);
        }
        
        public static T WithState<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withState", true);
        }
        
        public static T WithReceipt<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withReceipt", true);
        }
    }
}