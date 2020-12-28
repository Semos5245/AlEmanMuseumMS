using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ALEmanMuseum.Core.ExensionMethods
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
            => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        public static bool HasNumbers(this string value) 
            =>value.Any(letter => char.IsDigit(letter));
        public static bool EndsWith(this string value, IEnumerable<string> endings)
        {
            var endsWithOne = false;

            value = value.ToLower();

            foreach (var ending in endings)
            {
                if (endsWithOne) break;

                endsWithOne = value.EndsWith(ending);
            }

            return endsWithOne;

        }
        public static string ToPlural(this string word)
        {
            if (word?.IsNullOrEmptyOrWhiteSpace() ?? true)
                return string.Empty;

            if (word.ToLower().EndsWith("y") &&
                !"aeiou".Contains(word[^2]))
            {
                return $"{word.Substring(0, word.Length - 1)}ies";
            }
            else
                return
                    $"{word}" +
                    $"{(word.ToLower().EndsWith(new string[] { "s", "x", "z", "ch", "sh", }) ? "e" : "")}" +
                    $"s";
        }
        public static int ToInt32(this string value)
            => int.TryParse(value, out var intValue) ? intValue : default;
    }          
}              
