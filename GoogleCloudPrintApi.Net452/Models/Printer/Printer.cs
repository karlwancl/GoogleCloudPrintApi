using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class Printer
    {
        public Printer(string id, string name, string defaultDisplayName, string displayName, string description,
            PrinterType type, string proxy,  long createTime, long accessTime, long updateTime,bool isTosAccepted,
            List<string> tags, dynamic capabilities, string capsHash,CapabilitiesFormat capsFormat, string ownerId,
           string ownerName,  List<PrinterAcl> access, bool @public, bool quotaEnabled, int dailyQuota,  int currentQuota,
           LocalSettings local_settings, string uuid,string manufacturer, string model,string gcpVersion,  string setupUrl,
           string supportUrl, string updateUrl, string firmware, string supportedContentTypes, ConnectionStatusType connectionStatus,
           dynamic semanticState, dynamic uiState, int queuedJobsCount)
        {
            Id = id;
            Name = name;
            DefaultDisplayName = defaultDisplayName;
            DisplayName = displayName;
            Description = description;
            Type = type;
            Proxy = proxy;
            CreateTime = createTime;
            AccessTime = accessTime;
            UpdateTime = updateTime;
            IsTosAccepted = isTosAccepted;
            Tags = tags;
            Capabilities = capabilities;
            CapsHash = capsHash;
            CapsFormat = capsFormat;
            OwnerId = ownerId;
            OwnerName = ownerName;
            Access = access;
            Public = @public;
            QuotaEnabled = quotaEnabled;
            DailyQuota = dailyQuota;
            CurrentQuota = currentQuota;
            LocalSettings = local_settings;
            Uuid = uuid;
            Manufacturer = manufacturer;
            Model = model;
            GcpVersion = gcpVersion;
            SetupUrl = setupUrl;
            SupportUrl = supportUrl;
            UpdateUrl = updateUrl;
            Firmware = firmware;
            SupportedContentTypes = supportedContentTypes;
            ConnectionStatus = connectionStatus;
            SemanticState = semanticState;
            UiState = uiState;
            QueuedJobsCount = queuedJobsCount;
        }

        /// <summary>
        /// printer's GCP ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// system name of the printer
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// default printer display name
        /// </summary>
        public string DefaultDisplayName { get; private set; }

        /// <summary>
        /// user-specified printer display name
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// descriptive string about the printer
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// printer type (for possible types see the /search interface "type" parameter below)
        /// </summary>
        public PrinterType Type { get; private set; }

        /// <summary>
        /// connector through which this printer is run, if any
        /// </summary>
        public string Proxy { get;private set; }

        /// <summary>
        /// timestamp of when the printer was registered
        /// </summary>
        public long CreateTime { get; private set; }

        /// <summary>
        /// timestamp of last /fetch request sent by the printer (if the printer has never sent a /fetch, this field is equal to createTime)
        /// </summary>
        public long AccessTime { get; private set; }

        /// <summary>
        /// timestamp of last /update performed on the printer
        /// </summary>
        public long UpdateTime { get; private set; }

        /// <summary>
        /// whether the user needs to accept the printer's terms of service
        /// </summary>
        public bool IsTosAccepted { get; private set; }

        /// <summary>
        /// array of free-form strings provided by the printer/proxy or the Cloud Print server – any of the tags ^recent, ^connector, ^own, ^shared_directly, ^can_share, ^can_update, ^can_delete may be added by the server
        /// </summary>
        public List<string> Tags { get; private set; }

        /// <summary>
        /// returned in CDD or legacy format depending on the use_cdd parameter
        /// </summary>
        [PartiallySupported("Parse json dynamically")]
        public dynamic Capabilities { get; private set; }

        /// <summary>
        /// a hash or digest value of the capabilities data
        /// </summary>
        public string CapsHash { get; private set; }

        /// <summary>
        /// format of the capabilities if not CDD, can be "xps" or "ppd"
        /// </summary>
        public CapabilitiesFormat CapsFormat { get; private set; }

        /// <summary>
        /// printer owner's email address
        /// </summary>
        public string OwnerId { get; private set; }

        /// <summary>
        /// printer owner's name
        /// </summary>
        public string OwnerName { get;private  set; }

        /// <summary>
        /// printer's access control list, see Printer ACL
        /// </summary>
        public List<PrinterAcl> Access { get; private set; }

        /// <summary>
        /// whether printer is public (anyone can submit print jobs to it)
        /// </summary>
        public bool Public { get; private set; }

        /// <summary>
        /// whether quota restriction is enabled for a public printer
        /// </summary>
        public bool QuotaEnabled { get; private set; }

        /// <summary>
        /// number of pages each user is allotted to print per day on a quota-enabled public printer
        /// </summary>
        public int DailyQuota { get; private set; }

        /// <summary>
        /// number of pages the authenticated user has remaining to print today on a quota-enabled public printer
        /// </summary>
        public int CurrentQuota { get; private set; }

        /// <summary>
        /// printer's local settings
        /// </summary>
        public LocalSettings LocalSettings { get; private set; }

        #region GCP2.0 Printer fields

        /// <summary>
        /// Manufacturer-provided serial number of the printer.
        /// </summary>
        public string Uuid { get; private set; }

        /// <summary>
        /// Name of the printer manufacturer.
        /// </summary>
        public string Manufacturer { get; private set; }

        /// <summary>
        /// Printer model.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Version of the GCP protocol supported by the printer, e.g. "2.0".
        /// </summary>
        public string GcpVersion { get; private set; }

        /// <summary>
        /// URL with printer setup instructions.
        /// </summary>
        public string SetupUrl { get; private set; }

        /// <summary>
        /// URL that user should be directed to if they are in need of printer support.
        /// </summary>
        public string SupportUrl { get; private set; }

        /// <summary>
        /// URL that user should be directed to if printer needs a firmware update.
        /// </summary>
        public string UpdateUrl { get; private set; }

        /// <summary>
        /// Version of the printer's firmware.
        /// </summary>
        public string Firmware { get; private set; }

        /// <summary>
        /// Comma-separated list of content types that printer supports.
        /// </summary>
        public string SupportedContentTypes { get; private set; }

        #endregion

        #region Extra fields

        /// <summary>
        /// printer's connection status, which can be one of the following: ONLINE/ UNKNOWN/ OFFLINE/ DORMANT
        /// </summary>
        public ConnectionStatusType ConnectionStatus { get; private set; }

        /// <summary>
        /// printer's Cloud Device State as it was provided by the printer or software connector via the /register or /update API, with the "cloud_connection_state" field filled in based on the current connection status. For printers which do not have CDS, requesting this extra field will have no effect.
        /// </summary>
        [ PartiallySupported("Parse json dynamically")]
        public dynamic SemanticState { get; private set; }

        /// <summary>
        /// printer's Cloud Device UI State, which is a form of CDS localized for the authenticated user and convenient for display in a UI. Printers which do not have CDS are returned with a basic form of UI state based on their connection status when this field is requested.
        /// </summary>
        [PartiallySupported("Parse json dynamically")]
        public dynamic UiState { get; private set; }

        /// <summary>
        /// the number of jobs submitted to this printer that are currently in QUEUED state.
        /// </summary>
        public int QueuedJobsCount { get; private set; }

        #endregion
    }
}
