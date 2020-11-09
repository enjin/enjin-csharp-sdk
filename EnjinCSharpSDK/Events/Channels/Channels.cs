using System.Runtime.CompilerServices;
using Enjin.SDK.Models;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK.Events
{
    internal sealed class AppChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly int _appId;
        
        public AppChannel(Platform platform, int appId)
        {
            _platform = platform;
            _appId = appId;
        }

        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.app.{_appId}";
    }
    
    internal sealed class PlayerChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly int _appId;
        private readonly string _playerId;
        
        public PlayerChannel(Platform platform, int appId, string playerId)
        {
            _platform = platform;
            _appId = appId;
            _playerId = playerId;
        }
        
        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.app.{_appId}.player.{_playerId}";
    }

    internal sealed class TokenChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly string _tokenId;

        public TokenChannel(Platform platform, string tokenId)
        {
            _platform = platform;
            _tokenId = tokenId;
        }

        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.token.{_tokenId}";
    }
    
    internal sealed class WalletChannel : IChannel
    {
        private readonly Platform _platform;
        private readonly string _ethAddress;

        public WalletChannel(Platform platform, string ethAddress)
        {
            _platform = platform;
            _ethAddress = ethAddress;
        }

        public string Channel() => $"enjincloud.{_platform.Network.ToLower()}.wallet.{_ethAddress}";
    }
}