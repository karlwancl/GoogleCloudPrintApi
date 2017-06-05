using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class RegisterResponse : PrintersResponse<RegisterRequest>
    {
        public string PollingUrl { get; set; }

        public string InvitePageUrl { get; set; }

        public string CompleteInviteUrl { get; set; }

        public string AutomatedInviteUrl { get; set; }

        [JsonProperty("oauth_scope")]
        public string OAuthScope { get; set; }

        public int TokenDuration { get; set; }

        public string RegistrationToken { get; set; }

        public string InviteUrl { get; set; }
    }
}