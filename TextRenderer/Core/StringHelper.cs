using System;

namespace TextRenderer.Core
{
    /// <summary>
    /// Методы расширения для класса <see cref="string"/>
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Обрезает (если необходимо) строку до <paramref name="totalLength"/> символов добавляя в конце строки <paramref name="separator"/>
        /// </summary>
        public static string TruncateString(this string str, int totalLength, string separator = "...")
        {
            if (string.IsNullOrEmpty(separator))
            {
                throw new ArgumentNullException("separator");
            }
            if (str.Length <= totalLength)
            {
                return str;
            }
            return str.Substring(0, str.Length - separator.Length) + separator;
        }

        /// <summary>
        /// Обрезает (если необходимо) строку до <paramref name="totalLength"/> символов добавляя в середине строки <paramref name="separator"/>
        /// </summary>
        public static string TruncateStringInMiddle(this string str, int totalLength, string separator = "...")
        {
            if (string.IsNullOrEmpty(separator))
            {
                throw new ArgumentNullException("separator");
            }
            if (str.Length <= totalLength)
            {
                return str;
            }

            // количество символов которое можно оставить из начальной строки
            var totalCharsCountFromInitStr = totalLength - separator.Length;

            // оставляемое количество симоволов в конце строки
            var endCharsCount = totalCharsCountFromInitStr/2;
            // оставляемое количество симоволов в начале строки
            var startCharsCount = totalCharsCountFromInitStr - endCharsCount;
            return str.Substring(0, startCharsCount) + separator + str.Substring(str.Length - endCharsCount);
        }
    }
}