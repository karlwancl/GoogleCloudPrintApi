using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Parameters of /register interface, semantic_state is partially supported only
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// System name of the printer (need not be unique). (required)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Name of the printer to be displayed to users. If a default display name is not provided, the system name is displayed. (optional)
        /// </summary>
        public string DefaultDisplayName { get; set; }

        /// <summary>
        /// Identification of the printer client or proxy (many printers can share the same proxy). (required)
        /// </summary>
        [Required]
        public string Proxy { get; set; }

        /// <summary>
        /// Manufacturer-provided serial number of the printer. (required for GCP 2.0)
        /// </summary>
        [RequiredFor20]
        public string Uuid { get; set; }

        /// <summary>
        /// Name of the printer manufacturer. (required for GCP 2.0)
        /// </summary>
        [RequiredFor20]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Printer model. (required for GCP 2.0)
        /// </summary>
        [RequiredFor20]
        public string Model { get; set; }

        /// <summary>
        /// Version of the GCP protocol supported by the printer, e.g. "2.0". (required for GCP 2.0)
        /// </summary>
        [RequiredFor20]
        public string GCPVersion { get; set; }

        /// <summary>
        /// URL with printer setup instructions. (required for GCP 2.0)
        /// </summary>
        [RequiredFor20]
        public string SetupUrl { get; set; }

        /// <summary>
        /// URL that user should be directed to if they are in need of printer support. (required for GCP 2.0)
        /// </summary>
        [RequiredFor20]
        public string SupportUrl { get; set; }

        /// <summary>
        /// URL that user should be directed to if printer needs a firmware update. (required for GCP 2.0)
        /// </summary>
        [RequiredFor20]
        public string UpdateUrl { get; set; }

        /// <summary>
        /// Version of the printer's firmware. (required for GCP 2.0)
        /// </summary>
        [RequiredFor20]
        public string Firmware { get; set; }

        /// <summary>
        /// Current local settings of the printer (see Local settings). (optional, but recommended for GCP 2.0)
        /// </summary>
        [RecommendedFor20]
        public LocalSettings LocalSettings { get; set; }

        /// <summary>
        /// Current state of the printer in CDS format. (required for GCP 2.0)
        /// </summary>
        [RequiredFor20, PartiallySupported("Parse json dynamically")]
        public dynamic SemanticState { get; set; }

        /// <summary>
        /// Set this to "true" if the capabilities are provided in CDD format. (required to be true for GCP 2.0)
        /// </summary>
        [RequiredFor20("must set to true since gcp2 only supports cdd format for capabilities")]
        public bool UseCdd { get; set; }

        /// <summary>
        /// Printer capabilities (XPS, PPD or CDD). (required)
        /// </summary>
        public string Capabilities { get; set; }

        /// <summary>
        /// Printer default settings (XPS only). (required for XPS only)
        /// </summary>
        [RequiredForXps]
        public string Defaults { get; set; }

        /// <summary>
        /// A hash or digest value of the capabilities data. This value is useful, for example, to compare values and check whether the local printer's capabilities have changed. (optional)
        /// </summary>
        public string CapsHash { get; set; }

        /// <summary>
        /// Tags (free-form string values) to add to the printer. You can attach a set of unique tags to a printer, which may be useful to store additional metadata about the printer for later use by your application. (optional, repeated parameter)
        /// </summary>
        public List<string> Tag { get; set; }

        /// <summary>
        /// Private data to add to the printer. Private data values are similar to tags except that they are write-only; they can be added in /register and added or removed in /update, but they are never rendered in responses from the server. (optional, repeated parameter)
        /// </summary>
        public List<string> Data { get; set; }

        /// <summary>
        /// System name of the printer (need not be unique).
        /// </summary>
        [Obsolete]
        public string Printer { get; set; }

        /// <summary>
        /// Descriptive string about the printer.
        /// </summary>
        [Obsolete]
        public string Description { get; set; }

        /// <summary>
        /// Comma-separated list of content types that printer supports.
        /// </summary>
        [Obsolete]
        public string ContentTypes { get; set; }
    }
}