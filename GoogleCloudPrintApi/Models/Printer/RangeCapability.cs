namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Message that stores capability information specific to range-based capabilities.
	/// </summary>
	public class RangeCapability
    {
        public enum ValueTypeType
        {
            FLOAT,
            INTEGER
        }

		// Data type of the value of the range capability (required).
        public ValueTypeType ValueType { get; set; }

        public string Default { get; set; }

        public string Min { get; set; }

        public string Max { get; set; }
    }
}