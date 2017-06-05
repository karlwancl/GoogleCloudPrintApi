using GoogleCloudPrintApi.Attributes;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Share
{
    public class ShareRequest : IRequest
    {
        /// <summary>
        /// The ID of the printer being shared. (required)
        /// </summary>
        [Form(isRequiredFor: VersionOption.All)]
        public string PrinterId { get; set; }

        /// <summary>
        /// Email of the user or group or domain name to share the printer with. (required)
        /// </summary>
        [Form(isRequiredFor: VersionOption.All)]
        public string Scope { get; set; }

        /// <summary>
        /// The role the user or group is granted with. Can be either USER or MANAGER. (required)
        /// </summary>
        [Form(isRequiredFor: VersionOption.All)]
        public Role Role { get; set; }

        /// <summary>
        /// Set it to true to not send an invitation email to the scope the printer is shared with. (optional)
        /// </summary>
        [Form("skip_notification", addKeyOnlyIfBoolTrue: true)]
        public bool SkipNotification { get; set; }
    }
}