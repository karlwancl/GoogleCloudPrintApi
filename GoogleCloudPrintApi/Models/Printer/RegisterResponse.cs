using GoogleCloudPrintApi.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class RegisterResponse: PrintersResponse<RegisterRequest>
    {
        [JsonProperty]
        public string PollingUrl { get; private set; }

		[JsonProperty]
		public string InvitePageUrl { get; private set; }

		[JsonProperty]
		public string CompleteInviteUrl { get; private set; }

		[JsonProperty]
		public string AutomatedInviteUrl { get; private set; }

		[JsonProperty]
		public string OAuthScope { get; private set; }

		[JsonProperty]
		public int TokenDuration { get; private set; }

		[JsonProperty]
		public string RegistrationToken { get; private set; }

		[JsonProperty]
		public string InviteUrl { get; private set; }
    }
}