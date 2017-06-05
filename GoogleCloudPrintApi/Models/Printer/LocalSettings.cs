using GoogleCloudPrintApi.Attributes;
using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Local settings. Uses in RegisterRequest, use get; set;
    /// </summary>
    public class LocalSettings
    {
        public class Settings
        {
            /// <summary>
            /// Whether Privet local discovery is enabled (required).
            /// </summary>
            [Form("local_discovery")]
            public bool LocalDiscovery { get; set; }

            /// <summary>
            /// Whether Privet access token API should be exposed on the local network.
            /// </summary>
            [Form("access_token_enabled")]
            public bool AccessTokenEnabled { get; set; }

            /// <summary>
            /// Whether Privet local printing API should be exposed on the local network.
            /// </summary>
            [Form("printer/local_printing_enabled"), JsonProperty("printer/local_printing_enabled")]
            public bool PrinterLocalPrintingEnabled { get; set; }

            /// <summary>
            /// Whether Privet local printing may send jobs to the server for conversion.
            /// </summary>
            [Form("printer/conversion_printing_enabled"), JsonProperty("printer/conversion_printing_enabled")]
            public bool PrinterConversionPrintingEnabled { get; set; }

            /// <summary>
            /// Number of seconds between XMPP channel pings.
            /// </summary>
            [Form("xmpp_timeout_value")]
            public int XmppTimeoutValue { get; set; }
        }

        /// <summary>
        /// Current local settings.
        /// Required (for GCP 2.0) to be provided by the device via the /register
        /// interface. Should be provided or confirmed by the device via the /update
        /// interface as necessary. Prohibited to be provided by clients. Always
        /// present in the local_settings field returned by the /printer interface.
        /// </summary>

        public Settings Current { get; set; }

        /// <summary>
        /// Pending local settings.
        /// Prohibited to be provided by the device. Provided by clients via the
        /// /update interface. Present in the local_settings field returned by the
        /// /printer interface if a client has provided pending local settings but the
        /// device has not yet confirmed them as current.
        /// </summary>

        public Settings Pending { get; set; }
    }
}