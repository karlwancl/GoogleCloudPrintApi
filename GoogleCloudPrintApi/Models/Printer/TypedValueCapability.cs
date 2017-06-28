namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Message that stores capability information specific to typed-value-based capabilities.
	/// </summary>
	public class TypedValueCapability
    {
        public enum ValueTypeType
        {
            BOOLEAN,
            FLOAT,
            INTEGER,
            STRING
        }

		/// <summary>
		/// Type of data of the typed-value capability (required).
		/// </summary>
		/// <value>The type of the value.</value>
		public ValueTypeType ValueType { get; set; }

		/// <summary>
		/// Default value of the typed-value capability.
		/// </summary>
		/// <value>The default.</value>
		public string Default { get; set; }
    }
}