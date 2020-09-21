using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Represents the whitelist settings.
    /// </summary>
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