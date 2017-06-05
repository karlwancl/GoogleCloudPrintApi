using System;

namespace GoogleCloudPrintApi.Attributes
{
    /// <summary>
    /// Form key attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FormAttribute : System.Attribute
    {
        /// <summary>
        /// Gets the name of key for web call
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        /// Gets if the key is for which version
        /// </summary>
        /// <value>The flag.</value>
        public VersionOption IsFor { get; }

        /// <summary>
        /// Gets if the key is required for the web call on different version
        /// </summary>
        /// <value>The flag.</value>
        public VersionOption IsRequiredFor { get; }

        /// <summary>
        /// Gets a value indicating whether key is added to the form if the key returns true
        /// </summary>
        /// <value><c>true</c> if add key only if bool true; otherwise, <c>false</c>.</value>
        public bool AddKeyOnlyIfBoolTrue { get; }

        public FormAttribute(string name = null, VersionOption isFor = VersionOption.All, VersionOption isRequiredFor = VersionOption.None, bool addKeyOnlyIfBoolTrue = false)
        {
            AddKeyOnlyIfBoolTrue = addKeyOnlyIfBoolTrue;
            IsFor = isFor;
            IsRequiredFor = isRequiredFor;
            Name = name;
        }
    }
}