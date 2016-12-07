using GoogleCloudPrintApi.Infrastructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class LocalSettings : IJsonSerializable
    {
        public class Settings
        {
            // Couldn't use constructor to 'dispatch' values to fields since the field name contains invalid characters
            // The field values will not be readonly consider the case, may potentially cause bugs
            //public Settings(bool local_discovery, bool access_token_enabled, bool printer/local_printing_enabled)
            //{

            //}

            /// <summary>
            /// Whether Privet local discovery is enabled (required).
            /// </summary>
            [JsonProperty("local_discovery")]
            public bool LocalDiscovery { get; set; }

            /// <summary>
            /// Whether Privet access token API should be exposed on the local network.
            /// </summary>
            [JsonProperty("access_token_enabled")]
            public bool AccessTokenEnabled { get; set; }

            /// <summary>
            /// Whether Privet local printing API should be exposed on the local network.
            /// </summary>
            [JsonProperty("printer/local_printing_enabled")]
            public bool PrinterLocalPrintingEnabled { get; set; }

            /// <summary>
            /// Whether Privet local printing may send jobs to the server for conversion.
            /// </summary>
            [JsonProperty("printer/conversion_printing_enabled")]
            public bool PrinterConversionPrintingEnabled { get; set; }

            /// <summary>
            /// Number of seconds between XMPP channel pings.
            /// </summary>
            [JsonProperty("xmpp_timeout_value")]
            public int XmppTimeoutValue { get; set; }
        }

        /// <summary>
        /// Current local settings.
        /// Required (for GCP 2.0) to be provided by the device via the /register
        /// interface. Should be provided or confirmed by the device via the /update
        /// interface as necessary. Prohibited to be provided by clients. Always
        /// present in the local_settings field returned by the /printer interface.
        /// </summary>
        [JsonProperty("current")]
        public Settings Current { get; set; }

        /// <summary>
        /// Pending local settings.
        /// Prohibited to be provided by the device. Provided by clients via the
        /// /update interface. Present in the local_settings field returned by the
        /// /printer interface if a client has provided pending local settings but the
        /// device has not yet confirmed them as current.
        /// </summary>
        [JsonProperty("pending")]
        public Settings Pending { get; set; }
    }
}
