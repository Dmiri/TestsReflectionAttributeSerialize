using System;

namespace TestReflection.Base
{
    public class Destination
    {
        public uint Timeout { get; set; }
        public string String { get; set; }
        public Uri Uri { get; set; }
    }

    public class DestinationShort
    {
        public Uri Uri { get; set; }
    }
}
