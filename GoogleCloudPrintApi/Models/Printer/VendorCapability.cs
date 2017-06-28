using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Flexible capability that can represent range-based, selection-based, or
    /// typed-value-based capabilities.
    /// </summary>
    public class VendorCapability
    {
        public enum TypeType
        {
            RANGE,
            SELECT,
            TYPED_VALUE
        }

        /// <summary>
        /// ID of the capability. Used in CJT to associate a ticket item with this
        /// capability (required).
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Non-localized user-friendly string to represent this capability.
        /// New CDDs should use display_name_localized instead. It is required that
        /// either display_name or display_name_localized is set.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Type of this capability (required).
        /// </summary>
        /// <value>The type.</value>
        public TypeType Type { get; set; }

        /// <summary>
        /// Range-based capability definition.
        /// </summary>
        /// <value>The range cap.</value>
        public RangeCapability RangeCap { get; set; }

        /// <summary>
        /// Selection-based capability definition.
        /// </summary>
        /// <value>The select cap.</value>
        public SelectCapability SelectCap { get; set; }

        /// <summary>
        /// Typed-value-based capability definition.
        /// </summary>
        /// <value>The typed value cap.</value>
        public TypedValueCapability TypedValueCap { get; set; }

        /// <summary>
        /// Typed-value-based capability definition.
        /// </summary>
        /// <value>The display name localized.</value>
        public IList<LocalizedString> DisplayNameLocalized { get; set; }
    }
}