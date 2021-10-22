using JetBrains.Annotations;

namespace Enjin.SDK.Http
{
    /// <summary>
    /// Enum for different logging levels of HTTP traffic.
    /// </summary>
    [PublicAPI]
    public enum HttpLogLevel
    {
        /// <summary>
        /// No logging.
        /// </summary>
        NONE,

        /// <summary>
        /// Logs request and response lines.
        /// </summary>
        BASIC,

        /// <summary>
        /// Logs request and response lines as well as their respective headers.
        /// </summary>
        HEADERS,

        /// <summary>
        /// Logs request and response lines as well as their respective headers and bodies if present.
        /// </summary>
        BODY,
    }
}