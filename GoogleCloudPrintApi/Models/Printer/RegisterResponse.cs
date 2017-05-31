using GoogleCloudPrintApi.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class RegisterResponse: PrintersResponse<RegisterRequest>
    {
        [JsonProperty("polling_url")]
        public string PollingUrl { get; private set; }

        [JsonProperty("invite_page_url")]
        public string InvitePageUrl { get; private set; }

        [JsonProperty("complete_invite_url")]
        public string CompleteInviteUrl { get; private set; }

        [JsonProperty("automated_invite_url")]
        public string AutomatedInviteUrl { get; private set; }

        [JsonProperty("oauth_scope")]
        public string OAuthScope { get; private set; }

        [JsonProperty("token_duration")]
        public int TokenDuration { get; private set; }

        [JsonProperty("registration_token")]
        public string RegistrationToken { get; private set; }

        [JsonProperty("invite_url")]
        public string InviteUrl { get; private set; }
    }
}