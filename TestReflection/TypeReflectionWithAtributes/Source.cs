using Reflection.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestReflection.Attributes
{
    public class Source
    {
        public uint Timeout { get; set; }
        [Name("String")]
        public string Note { get; set; }
        [Name("Note")]
        public string String { get; set; }
        public Uri Uri { get; set; }
    }

    public class SourceNotMapped
    {
        public uint Timeout { get; set; }
        [NotMapped]
        public string Note { get; set; }
        [NotMapped]
        public string String { get; set; }
        public Uri Uri { get; set; }
    }

    public class SourceNotMappedAll
    {
        [NotMapped]
        public uint Timeout { get; set; }
        [NotMapped]
        public string Note { get; set; }
        [NotMapped]
        public string String { get; set; }
        [NotMapped]
        public Uri Uri { get; set; }
    }

    public class SourceShort
    {
        [Name("String")]
        public string Note { get; set; }
        public Uri Uri { get; set; }
    }
}
