using System.Collections.Generic;

namespace GoogleCloudPrintApi.Exception
{
    public class KeyRequiredException : System.Exception
    {
        public IEnumerable<string> Names { get; }

        public KeyRequiredException(params string[] names)
        {
            Names = names;
        }

        public override string Message => $"The keys \"{string.Join("; ", Names)}\" are marked as required, please double check if the key is set";
    }
}