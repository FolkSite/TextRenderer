using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TextRenderer.Core;

namespace TextRenderer.HtmlHelpers
{
    public static class TextWrapperHelper
    {
        /// <summary>
        /// Разбивает тектс на строки. Оборачивает ссылки в html-тег "ссылка"
        /// </summary>
        public static HtmlString WrappedText(this HtmlHelper helper, string text, int textLineMaxLength)
        {
            const string newLine = @"<br/>";

            var words = text.Split(' ');
            var counter = 0;
            var sb = new StringBuilder();
            foreach (var word in words)
            {
                if (counter >= textLineMaxLength)
                {
                    sb.Append(newLine);
                    counter = 0;
                }
                var currentWord = word;
                Uri uri;
                if (Uri.TryCreate(word, UriKind.Absolute, out uri))
                {
                    // если ссылка
                    var truncatedUrlStr = word.TruncateStringInMiddle(textLineMaxLength);
                    if (truncatedUrlStr.Length > textLineMaxLength - counter)
                    {
                        // если не помещается на доступном месте в текущей строке, то  переходим на новую строку
                        sb.Append(newLine);
                        counter = 0;
                    }
                    sb.AppendFormat("<a href='{0}' title='{0}'>{1}</a>", word, truncatedUrlStr);
                    counter += truncatedUrlStr.Length;
                    if (counter < textLineMaxLength)
                    {
                        sb.Append(" ");
                        counter++;
                    }
                    continue;
                }
                
                // количество символов доступных на текущей строке
                if (currentWord.Length > textLineMaxLength)
                {
                    // если слово больше макс длины строки
                    while (currentWord.Length > textLineMaxLength - counter)
                    {
                        sb.Append(word.Substring(0, textLineMaxLength - counter));
                        currentWord = currentWord.Substring(textLineMaxLength - counter);
                        sb.Append(newLine);
                        counter = 0;
                    }
                }
                else if (currentWord.Length > textLineMaxLength - counter)
                {
                    // если слово больше чем осталось места на строке
                    sb.Append(newLine);
                    counter = 0;
                }
                sb.Append(currentWord);
                counter += currentWord.Length;
                if (counter < textLineMaxLength)
                {
                    sb.Append(" ");
                    counter++;
                }
            }
            return new HtmlString(sb.ToString());
        }
    }
}