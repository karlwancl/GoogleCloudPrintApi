using GoogleCloudPrintApi.Attributes;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class RegisterResponse
    {
        public RegisterResponse(bool success, string xsrf_token, dynamic request, List<Printer> printers, string polling_url,
            string invite_page_url, string complete_invite_url, string automated_invite_url, string oauth_scope,
            int token_duration, string registration_token, string invite_url)
        {
            Success = success;
            XsrfToken = xsrf_token;
            Request = request;
            Printers = printers;
            PollingUrl = polling_url;
            InvitePageUrl = invite_page_url;
            CompleteInviteUrl = complete_invite_url;
            AutomatedInviteUrl = automated_invite_url;
            OAuthScope = oauth_scope;
            TokenDuration = token_duration;
            RegistrationToken = registration_token;
            InviteUrl = invite_url;
        }

        public bool Success { get; private set; }

        public string XsrfToken { get; private set; }

        [PartiallySupported("Parse json dynamically")]
        public dynamic Request { get; private set; }

        public List<Printer> Printers { get; private set; }

        [RequiredForAnonymousRegistration]
        public string PollingUrl { get; private set; }

        [RequiredForAnonymousRegistration]
        public string InvitePageUrl { get; private set; }

        [RequiredForAnonymousRegistration]
        public string CompleteInviteUrl { get; private set; }

        [RequiredForAnonymousRegistration]
        public string AutomatedInviteUrl { get; private set; }

        [RequiredForAnonymousRegistration]
        public string OAuthScope { get; private set; }

        [RequiredForAnonymousRegistration]
        public int TokenDuration { get; private set; }

        [RequiredForAnonymousRegistration]
        public string RegistrationToken { get; private set; }

        [RequiredForAnonymousRegistration]
        public string InviteUrl { get; private set; }
    }
}