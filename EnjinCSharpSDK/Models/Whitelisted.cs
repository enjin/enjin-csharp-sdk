using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
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