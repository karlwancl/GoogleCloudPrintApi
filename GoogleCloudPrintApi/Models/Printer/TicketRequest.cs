using GoogleCloudPrintApi.Attributes;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class TicketRequest : IRequest
    {
        /// <summary>
        /// The job id of the cloud job ticket
        /// </summary>
        [Form(isFor: VersionOption.V2, isRequiredFor: VersionOption.All)]
        public string JobId { get; set; }

        /// <summary>
        /// Flag to control if use cloud job ticket or not
        /// </summary>
        [Form("use_cjt", VersionOption.V2)]
        public bool UseCjt { get; set; } = true;
    }
}