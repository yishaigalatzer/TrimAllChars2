using System;

namespace Trimmer
{
    public static class Extensions
    {
        /// <summary>
        /// Trim all chars and whitespace combined
        /// </summary>
        /// <example>
        /// " a ".TrimSpacesAndChars() -> "a"
        /// " a/ / ".TrimSpaceAndChars('/') -> "a"
        /// </example>
        /// <param name="value">non null string to be trimmed.</param>
        /// <param name="chars">optional chars to trim with on top of whitespaces.</param>
        /// <returns></returns>
        public static string TrimSpacesAndChars(this string value, params char[] chars)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            if (chars == null || chars.Length == 0)
            {
                return value.Trim();
            }

            int firstIndex = 0;

            for (; firstIndex < value.Length; firstIndex++)
            {
                char currentChar = value[firstIndex];

                if (!Char.IsWhiteSpace(currentChar) && !currentChar.EqualsAny(chars))
                {
                    break;
                }
            }

            // we trimmed all the way
            if (firstIndex == value.Length)
            {
                return string.Empty;
            }

            int lastIndex = value.Length - 1;

            for (; lastIndex > firstIndex; lastIndex--)
            {
                char currentChar = value[lastIndex];

                if (!Char.IsWhiteSpace(currentChar) && !currentChar.EqualsAny(chars))
                {
                    break;
                }
            }

            if (lastIndex == value.Length - 1 && firstIndex == 0)
            {
                return value;
            }
            else
            {
                return value.Substring(firstIndex, lastIndex - firstIndex + 1);
            }
        }

        private static bool EqualsAny(this char input, char[] chars)
        {
            foreach (var compareChar in chars)
            {
                if (input == compareChar)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
