using Reflection.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ReflectionWithAttributes
{
    public static class Reflection
    {
        public static PropertyInfo[] GetSameProps(this PropertyInfo[] propertySource, PropertyInfo[] propertyDestination)
        {
            foreach (var item in propertySource)
            {
                var prop = GetPropertyFromListByProperty(propertyDestination, item);
                if (prop == null)
                {
                    return null;
                }
            }

            return propertySource;
        }

        private static PropertyInfo GetPropertyFromListByProperty(PropertyInfo[] propertyList, PropertyInfo property) {
            var sourceAtrName = property.GetCustomAttribute<NameAttribute>()?.propertyName;
            PropertyInfo prop = null;
            var foundingName = property.Name;
            if (sourceAtrName != null)
            {
                foundingName = sourceAtrName;
            }

            prop = propertyList
                .FirstOrDefault(p => p.GetCustomAttribute<NameAttribute>()?.propertyName == foundingName);
            if (prop == null)
                prop = propertyList.FirstOrDefault(p => p.Name == foundingName);
            if (prop == null || prop.PropertyType != property.PropertyType)
            {
                return null;
            }

            return prop;
        }

        public static object CopyTo(this object source, object destination)
        {
            if (source == null || destination == null)
                return destination;

            var sourceType = source.GetType();
            var destinationType = destination.GetType();

            var propertySource = sourceType.GetProperties()
                .Where(p => p.GetCustomAttribute<NotMappedAttribute>() == null)
                .ToArray();
            var propertyDestination = destinationType.GetProperties()
                .Where(p => p.GetCustomAttribute<NotMappedAttribute>() == null)
                .ToArray();
            var sameProps = GetSameProps(propertySource, propertyDestination);

            if (sameProps != null && sameProps.Length > 0)
            {
                foreach (var item in sameProps)
                {
                    var value = item.GetValue(source);
                    if (value != null)
                    {
                        var prop = GetPropertyFromListByProperty(propertyDestination, item);
                        prop.SetValue(destination, value);
                    }
                }
            }

            return destination;
        }
    }
}