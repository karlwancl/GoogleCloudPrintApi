namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Physical model of a media path of a printer. Media paths are the paths
	/// through which print media flows.
	/// </summary>
	public class MediaPath
    {
		/// <summary>
		/// Vendor-provided ID of a media path (required).
		/// </summary>
		/// <value>The vendor identifier.</value>
		public string VendorId { get; set; }
    }
}