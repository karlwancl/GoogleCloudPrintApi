using GoogleCloudPrintApi.Attributes;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class ListRequest : IRequest
    {
        /// <summary>
        /// Identification of the proxy, as submitted while registering the printer. (required)
        /// </summary>
        [Form(isRequiredFor: VersionOption.All)]
        public string Proxy { get; set; }

        /// <summary>
        /// Comma-separated list of extra fields to include in the returned printer objects, see Extra Fields for Printers for more information. The queuedJobsCount extra field is useful here so that a software connector does not need to make a /fetch call for printers with zero queued jobs. Note that the /printer interface must be used in order to retrieve a printer's capabilities. (optional)
        /// </summary>
        [Form("extra_fields")]
        public string ExtraFields { get; set; }
    }
}