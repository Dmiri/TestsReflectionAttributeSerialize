using System;

namespace Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NameAttribute : Attribute
    {
        public readonly string propertyName;
        public NameAttribute(string name)
        {
            propertyName = name;
        }

        public string Name { get => propertyName; }
    }
}
