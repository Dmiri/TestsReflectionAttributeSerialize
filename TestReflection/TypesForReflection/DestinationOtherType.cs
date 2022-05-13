using System;
using System.Text;

namespace TestReflection.Base
{
    public class DestinationOtherType
    {
        public int Timeout { get; set; }
        public StringBuilder String { get; set; }
        public Uri Uri { get; set; }
    }

    public class DestinationOtherTypeShort
    {
        public Uri Uri { get; set; }
    }
}
