using GoogleCloudPrintApi.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class Printer
    {
        /// <summary>
        /// printer's GCP ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// system name of the printer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// default printer display name
        /// </summary>
        [JsonProperty("defaultDisplayName")]  // Don't know why Json.NET do not parse it correctly
        public string DefaultDisplayName { get; set; }

        /// <summary>
        /// user-specified printer display name
        /// </summary>
        [JsonProperty("displayName")]  // Don't know why Json.NET do not parse it correctly
        public string DisplayName { get; set; }

        /// <summary>
        /// descriptive string about the printer
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// printer type (for possible types see the /search interface "type" parameter below)
        /// </summary>
        public PrinterType Type { get; set; }

        /// <summary>
        /// connector through which this printer is run, if any
        /// </summary>
        public string Proxy { get; set; }

        /// <summary>
        /// timestamp of when the printer was registered
        /// </summary>
        [JsonProperty("createTime")]
        public long CreateTime { get; set; }

        /// <summary>
        /// timestamp of last /fetch request sent by the printer (if the printer has never sent a /fetch, this field is equal to createTime)
        /// </summary>
        [JsonProperty("accessTime")]
        public long AccessTime { get; set; }

        /// <summary>
        /// timestamp of last /update performed on the printer
        /// </summary>
        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; }

        /// <summary>
        /// whether the user needs to accept the printer's terms of service
        /// </summary>
        [JsonProperty("isTosAccepted")]
        public bool IsTosAccepted { get; set; }

        /// <summary>
        /// array of free-form strings provided by the printer/proxy or the Cloud Print server – any of the tags ^recent, ^connector, ^own, ^shared_directly, ^can_share, ^can_update, ^can_delete may be added by the server
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// returned in CDD or legacy format depending on the use_cdd parameter
        /// </summary>
        [PartiallySupported("Parse json dynamically")]
        public dynamic Capabilities { get; set; }

        /// <summary>
        /// a hash or digest value of the capabilities data
        /// </summary>
        [JsonProperty("capsHash")]
        public string CapsHash { get; set; }

        /// <summary>
        /// format of the capabilities if not CDD, can be "xps" or "ppd"
        /// </summary>
        [JsonProperty("capsFormat")]
        public CapabilitiesFormat CapsFormat { get; set; }

        /// <summary>
        /// printer owner's email address
        /// </summary>
        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// printer owner's name
        /// </summary>
        [JsonProperty("ownerName")]
        public string OwnerName { get; private set; }

        /// <summary>
        /// printer's access control list, see Printer ACL
        /// </summary>
        public List<PrinterAcl> Access { get; set; }

        /// <summary>
        /// whether printer is public (anyone can submit print jobs to it)
        /// </summary>
        public bool Public { get; set; }

        /// <summary>
        /// whether quota restriction is enabled for a public printer
        /// </summary>
        public bool QuotaEnabled { get; set; }

        /// <summary>
        /// number of pages each user is allotted to print per day on a quota-enabled public printer
        /// </summary>
        public int DailyQuota { get; set; }

        /// <summary>
        /// number of pages the authenticated user has remaining to print today on a quota-enabled public printer
        /// </summary>
        public int CurrentQuota { get; set; }

        /// <summary>
        /// printer's local settings
        /// </summary>
        public LocalSettings LocalSettings { get; set; }

        /// <summary>
        /// Gets or sets the status.    (Found in RegisterResponse)
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }

        #region GCP2.0 Printer fields

        /// <summary>
        /// Manufacturer-provided serial number of the printer.
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Name of the printer manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Printer model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Version of the GCP protocol supported by the printer, e.g. "2.0".
        /// </summary>
        [JsonProperty("gcpVersion")]
        public string GcpVersion { get; set; }

        /// <summary>
        /// URL with printer setup instructions.
        /// </summary>
        public string SetupUrl { get; set; }

        /// <summary>
        /// URL that user should be directed to if they are in need of printer support.
        /// </summary>
        public string SupportUrl { get; set; }

        /// <summary>
        /// URL that user should be directed to if printer needs a firmware update.
        /// </summary>
        public string UpdateUrl { get; set; }

        /// <summary>
        /// Version of the printer's firmware.
        /// </summary>
        public string Firmware { get; set; }

        /// <summary>
        /// Comma-separated list of content types that printer supports.
        /// </summary>
        [JsonProperty("supportedContentTypes")]
        public string SupportedContentTypes { get; set; }

        #endregion GCP2.0 Printer fields

        #region Extra fields

        /// <summary>
        /// printer's connection status, which can be one of the following: ONLINE/ UNKNOWN/ OFFLINE/ DORMANT
        /// </summary>
        public ConnectionStatusType ConnectionStatus { get; set; }

        /// <summary>
        /// printer's Cloud Device State as it was provided by the printer or software connector via the /register or /update API, with the "cloud_connection_state" field filled in based on the current connection status. For printers which do not have CDS, requesting this extra field will have no effect.
        /// </summary>
        [PartiallySupported("Parse json dynamically")]
        public dynamic SemanticState { get; set; }

        /// <summary>
        /// printer's Cloud Device UI State, which is a form of CDS localized for the authenticated user and convenient for display in a UI. Printers which do not have CDS are returned with a basic form of UI state based on their connection status when this field is requested.
        /// </summary>
        [PartiallySupported("Parse json dynamically")]
        public dynamic UiState { get; set; }

        /// <summary>
        /// the number of jobs submitted to this printer that are currently in QUEUED state.
        /// </summary>
        public int QueuedJobsCount { get; set; }

        #endregion Extra fields
    }
}