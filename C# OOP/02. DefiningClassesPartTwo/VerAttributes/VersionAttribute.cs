using System;

namespace VerAttributes
{
    [AttributeUsage(AttributeTargets.Struct |
        AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method)]
    class VersionAttribute : System.Attribute
    {
        public double Version { get; private set; }

        public VersionAttribute(double version)
        {
            this.Version = version;
        }
    }
}