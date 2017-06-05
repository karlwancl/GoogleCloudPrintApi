namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Description of how a cloud job (e.g. print job, scan job) should be handled by the cloud device. Also known as CJT.
    /// Uses in SumbitRequest, uses get; set;
    /// </summary>
    public class CloudJobTicket
    {
        /// <summary>
        /// Version of the CJT in the form "X.Y" where changes to Y are backwards compatible, and changes to X are not (required).
        /// </summary>
        public string Version { get; set; } = "1.0";

        /// <summary>
        /// Section of CJT pertaining to cloud printer ticket items.
        /// </summary>
        public PrintTicketSection Print { get; set; }

        /// <summary>
        /// Section of CJT pertaining to cloud scanner ticket items. (Not implemented yet)
        /// </summary>
        public ScanTicketSection Scan { get; set; }
    }
}