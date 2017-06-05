using System;

namespace GoogleCloudPrintApi.Attributes
{
    [Flags]
    public enum VersionOption
    {
        V1 = 1 << 0,
        V2 = 1 << 1,
        All = V1 | V2,
        None = 1 << 2
    }
}