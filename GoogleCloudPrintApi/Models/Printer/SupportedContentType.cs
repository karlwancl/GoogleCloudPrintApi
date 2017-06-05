namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Property that defines what content types the printer can print natively.
    /// </summary>
    public class SupportedContentType
    {
        /// <summary>
        /// Content type (e.g. "image/png" or "application/pdf"). Use */* if your printer supports all formats (required).
        /// </summary>
        /// <value>The type of the content.</value>
        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// Minimum supported version of the content type if applicable (e.g. "1.5").
        /// </summary>
        /// <value>The minimum version.</value>
        public string MinVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Maximum supported version of the content type if applicable (e.g. "1.5").
        /// </summary>
        /// <value>The max version.</value>
        public string MaxVersion
        {
            get;
            set;
        }
    }
}