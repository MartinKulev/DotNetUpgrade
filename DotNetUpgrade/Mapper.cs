using System.Reflection;

namespace DotNetUpgrade
{
    public static class Mapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            if (source == null || destination == null)
            {
                throw new ArgumentNullException("Source or destination cannot be null.");
            }

            PropertyInfo[] sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] sourceFields = typeof(TSource).GetFields(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo sourceProp in sourceProperties)
            {
                var destProp = destinationProperties
                    .FirstOrDefault(dp => dp.Name.Equals(sourceProp.Name, StringComparison.OrdinalIgnoreCase) &&
                                          dp.PropertyType == sourceProp.PropertyType);

                if (destProp != null && destProp.CanWrite)
                {
                    destProp.SetValue(destination, sourceProp.GetValue(source));
                }
            }

            foreach (FieldInfo sourceField in sourceFields)
            {
                var destProp = destinationProperties
                    .FirstOrDefault(dp => dp.Name.Equals(sourceField.Name, StringComparison.OrdinalIgnoreCase) &&
                                          dp.PropertyType == sourceField.FieldType);

                if (destProp != null && destProp.CanWrite)
                {
                    destProp.SetValue(destination, sourceField.GetValue(source));
                }
            }

            return destination;
        }
    }
}
