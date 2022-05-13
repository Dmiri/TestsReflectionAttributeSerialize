using System;
using System.ComponentModel.DataAnnotations.Schema;
using Reflection.Attributes;

namespace TestReflection.Attributes
{
    public class Destination
    {
        [Name("Timeout")]
        public uint Time { get; set; }
        [Name("String")]
        public string Note { get; set; }
        [Name("Note")]
        public string String { get; set; }
        public Uri Uri { get; set; }
        [NotMapped]
        public DateTime CreatedDT { get; set; }
    }

    public class DestinationShort
    {
        public Uri Uri { get; set; }
    }
}
