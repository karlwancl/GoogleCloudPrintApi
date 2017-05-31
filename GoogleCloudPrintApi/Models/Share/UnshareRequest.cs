using GoogleCloudPrintApi.Attributes;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Share
{
    public class UnshareRequest: IRequest
    {
        /// <summary>
        /// The ID of the printer to unshare. (required)
        /// </summary>
        [FormKey(isRequiredFor: VersionOption.All)]
        public string PrinterId { get; set; }

        /// <summary>
        /// Email of the user or group or domain name to delete from the printer's ACL. (required)
        /// </summary>
        [FormKey(isRequiredFor: VersionOption.All)]
        public string Scope { get; set; }
    }
}