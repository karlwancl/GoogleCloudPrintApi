using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi
{
    public class GoogleCloudPrintOAuth2Provider : GoogleOAuth2ProviderBase
    {
        public GoogleCloudPrintOAuth2Provider(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
        }

        protected override string Scope => "https://www.googleapis.com/auth/cloudprint https://www.googleapis.com/auth/googletalk email";
    }
}
