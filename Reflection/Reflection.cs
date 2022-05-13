using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public static class Reflection
    {
        //public static bool IsSame(this Type source, Type destination)
        //{
        //    var propertySource = source.GetProperties();
        //    var propertyDestination = destination.GetProperties();

        //    foreach (var item in propertySource)
        //    {
        //        var props = propertyDestination.FirstOrDefault(p => p.Name == item.Name);
        //        if (props == null || props.PropertyType != item.PropertyType)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}


        public static bool IsSame(this Type source, Type destination)
        {
            var sameProps = GetSameProps(source, destination);
            if (sameProps != null && sameProps.Length > 0)
                return true;
            return false;
        }

        public static PropertyInfo[] GetSameProps(this Type source, Type destination)
        {
            var propertySource = source.GetProperties();
            var propertyDestination = destination.GetProperties();

            foreach (var item in propertySource)
            {
                var props = propertyDestination.FirstOrDefault(p => p.Name == item.Name);
                if (props == null || props.PropertyType != item.PropertyType)
                {
                    return null;
                }
            }

            return propertySource;
        }

        public static object CopyTo(this object source, object destination)
        {
            if (source == null || destination == null)
                return destination;

            var sourceType = source.GetType();
            var destinationType = destination.GetType();

            var sameProps = GetSameProps(sourceType, destinationType);

            if (sameProps != null && sameProps.Length > 0)
            {
                foreach (var item in sameProps)
                {
                    var value = item.GetValue(source);
                    if (value != null)
                    {
                        var prop = destinationType.GetProperty(item.Name);
                        prop.SetValue(destination, value);
                    }
                }
            }

            return destination;
        }
    }
}
