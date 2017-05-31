using GoogleCloudPrintApi.Attributes;
using GoogleCloudPrintApi.Infrastructures;
using GoogleCloudPrintApi.Models.Printer;

namespace GoogleCloudPrintApi.Models.Application
{
	public class SearchRequest: IRequest
    { 
		/// <summary>
		/// If q is specified, then only printers whose name, display name, or tags contain the given query as a substring (case-insensitively) will be returned.
		/// Setting q=^recent will return the list of recently used printers, which will have all fields including capabilities.
		/// Setting q=^own or q=^shared will return the list of printers owned by or shared with the user, respectively.
		/// If q is not specified, then all printers accessible to (owned by or shared with) the authenticated user will be returned.
		/// </summary>
        [FormKey]
		public string Q { get; set; }

		/// <summary>
		/// If type is specified, then only printers of the given type will be returned.
		/// </summary>
        [FormKey]
		public PrinterType? Type { get; set; }

		/// <summary>
		/// If connection_status is specified, then only printers whose connection status matches the supplied value will be returned. 
		/// </summary>
        [FormKey("connection_status")]
		public ConnectionStatusType? ConnectionStatus { get; set; }

		/// <summary>
		/// If q contains the substring "^recent", then providing use_cdd=true will cause the capabilities of the returned printers to be in CDD format; if q does not contain "^recent" then this parameter has no effect.
		/// </summary>
        [FormKey("use_cdd")]
		public bool? UseCdd { get; set; }

		/// <summary>
		/// Comma-separated list of extra fields to include in the returned printer objects, see Extra Fields for Printers for more information. For backward compatibility, connectionStatus is always returned when the extra_fields parameter is omitted.
		/// </summary>
        [FormKey("extra_fields")]
		public string ExtraFields { get; set; }
	}
}