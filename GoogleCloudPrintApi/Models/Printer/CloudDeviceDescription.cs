namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Description of a cloud-enabled device's capabilities and properties. Also known as CDD.
    /// </summary>
    public class CloudDeviceDescription
    {
        /// <summary>
        /// Version of the CDD in the form "X.Y" where changes to Y are backwards compatible, and changes to X are not (required).
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Section of the CDD that specifically describes printers.
        /// </summary>
        /// <value>The printer.</value>
        public PrinterDescriptionSection Printer { get; set; }

        /// <summary>
        /// Section of the CDD that specifically describes scanners.
        /// </summary>
        /// <value>The scanner.</value>
        public ScannerDescriptionSection Scanner { get; set; }
    }
}