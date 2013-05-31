using System;

namespace Attribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
        AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method,
        AllowMultiple = false)]

    public class VersionAttribute : System.Attribute
    {
        public string Version { get; private set; }

        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}
