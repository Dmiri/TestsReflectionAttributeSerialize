using Reflection.Attributes;
using System;

namespace TestReflection.Base
{
    public class Source
    {
        public uint Timeout { get; set; }
        public string String { get; set; }
        public Uri Uri { get; set; }
    }

    public class SourceShort
    {
        [Name("String")]
        public Uri Uri { get; set; }
    }
}
