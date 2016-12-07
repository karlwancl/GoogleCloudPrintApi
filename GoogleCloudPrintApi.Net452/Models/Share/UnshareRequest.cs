using GoogleCloudPrintApi.Attributes;

namespace GoogleCloudPrintApi.Models.Share
{
    public class UnshareRequest
    {
        /// <summary>
        /// The ID of the printer to unshare. (required)
        /// </summary>
        [Required]
        public string PrinterId { get; set; }

        /// <summary>
        /// Email of the user or group or domain name to delete from the printer's ACL. (required)
        /// </summary>
        [Required]
        public string Scope { get; set; }
    }
}