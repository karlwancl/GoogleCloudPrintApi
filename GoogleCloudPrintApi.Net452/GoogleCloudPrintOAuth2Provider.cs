using GoogleCloudPrintApi.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi
{
    public class GoogleCloudPrintOAuth2Provider : GoogleOAuth2ProviderBase
    {
        public GoogleCloudPrintOAuth2Provider(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
        }

        protected override string Scope => "https://www.googleapis.com/auth/cloudprint";
    }
}
