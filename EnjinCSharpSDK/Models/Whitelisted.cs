using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public enum Whitelisted
    {
        NONE,
        SEND_AND_RECEIVE,
        SEND,
        RECEIVE,
        NO_FEES,
        ADDRESS
    }
}