using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class PrinterRequest: IRequest
    {
		/// <summary>
        /// The ID of the printer whose capabilities are desired. The printer must be either owned by or shared with the authenticated user. (Required)
		/// </summary>
		/// <value>The printer identifier.</value>
        [FormKey(isRequiredFor: VersionOption.All)]
		public string PrinterId { get; set; }

		/// <summary>
		/// Include this parameter with any value (possibly the client name) to augment the printer's capabilities with options that can managed by the server. Some options that can be added (depending on the printer) are page range, orientation, page fitting.
		/// </summary>
		/// <value>The client.</value>
        [FormKey]
		public string Client { get; set; }

		/// <summary>
		/// Comma-separated list of extra fields to include in the returned printer object, see Extra Fields for Printers for more information.
		/// </summary>
		/// <value>The extra fields.</value>
        [FormKey("extra_fields")]
		public string ExtraFields { get; set; }

		/// <summary>
		/// Include use_cdd=false to receive printer capabilities as provided by the printer instead of in CDD format. (Capabilities in legacy formats are normally translated to CDD.) It is recommended ignoring this option in new client development.
		/// </summary>
		/// <value><c>true</c> if use cdd; otherwise, <c>false</c>.</value>
        [FormKey("use_cdd"), Obsolete]
        public bool UseCdd { get; set; }

		/// <summary>
		/// A Boolean that specifies whether or not to return the printer's connectionStatus field.
		/// </summary>
		/// <value><c>true</c> if printer connection status; otherwise, <c>false</c>.</value>
		[FormKey("printer_connection_status", addKeyOnlyIfBoolTrue: true), Obsolete("please use extra_fields instead")]
        public bool PrinterConnectionStatus { get; set; }
    }
}
