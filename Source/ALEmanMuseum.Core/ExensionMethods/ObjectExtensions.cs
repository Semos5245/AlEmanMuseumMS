using System;
using System.Linq;

namespace ALEmanMuseum.Core.ExensionMethods
{
    public static class ObjectExtensions
    {
        public static T TrimObject<T>(this T obj) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var objectType = typeof(T);

            if (objectType == typeof(string))
            {
                return obj.ToString().Trim() as T;
            }
            else if (objectType.IsClass && !objectType.IsInterface && objectType != typeof(string))
            {
                foreach (var stringProperties in objectType.GetProperties().Where(p => p.CanWrite && p.CanRead && p.PropertyType == typeof(string)))
                {
                    stringProperties.SetValue(obj, ((string)stringProperties.GetValue(obj))?.Trim(), null);
                }

                return obj;
            }

            throw new InvalidOperationException("Can't apply trimming on the current object");
        }

        public static T As<T>(this object obj) where T : class
            => obj as T;
    }
}
