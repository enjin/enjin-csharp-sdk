using System.Runtime.CompilerServices;
using Enjin.SDK.Models;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK.Events
{
    internal sealed class PusherAppChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly int _appId;
        
        public PusherAppChannel(Platform platform, int appId)
        {
            _platform = platform;
            _appId = appId;
        }

        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.app.{_appId}";
    }
    
    internal sealed class PusherPlayerChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly int _appId;
        private readonly string _playerId;
        
        public PusherPlayerChannel(Platform platform, int appId, string playerId)
        {
            _platform = platform;
            _appId = appId;
            _playerId = playerId;
        }
        
        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.app.{_appId}.player.{_playerId}";
    }

    internal sealed class PusherTokenChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly string _tokenId;

        public PusherTokenChannel(Platform platform, string tokenId)
        {
            _platform = platform;
            _tokenId = tokenId;
        }

        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.token.{_tokenId}";
    }
    
    internal sealed class PusherWalletChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly string _ethAddress;

        public PusherWalletChannel(Platform platform, string ethAddress)
        {
            _platform = platform;
            _ethAddress = ethAddress;
        }

        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.wallet.{_ethAddress}";
    }
}