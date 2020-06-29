namespace EnjinSDK.Models
{
    public class AccessToken
    {
        public string accessToken { get; private set; }
        public long expiresIn { get; private set; }

        public override string ToString()
        {
            return $"{nameof(accessToken)}: {accessToken}, {nameof(expiresIn)}: {expiresIn}";
        }
    }
}