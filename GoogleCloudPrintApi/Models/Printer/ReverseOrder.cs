namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Capability that defines the default reverse-printing-order setting on a device.
	/// </summary>
	public class ReverseOrder
    {
        public bool Default { get; set; } = false;
    }
}