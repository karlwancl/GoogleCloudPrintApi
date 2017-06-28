namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Capability that defines a default and maximum value for multiple copies on a
	/// device.
	/// </summary>
	public class Copies
    {
        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        /// <value>The default.</value>
        public int Default { get; set; }

        /// <summary>
        /// Gets or sets the max.
        /// </summary>
        /// <value>The max.</value>
        public int Max { get; set; }
    }
}