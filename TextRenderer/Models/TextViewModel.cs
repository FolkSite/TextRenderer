using System.Configuration;

namespace TextRenderer.Models
{
    /// <summary>
    /// Модель представления текста с переносом по строкам
    /// </summary>
    public class TextViewModel
    {
        /// <summary>
        /// Максимальная длина строки текста по умолчанию
        /// </summary>
        private const int DefaultTextLineMaxLength = 20;

        /// <summary>
        /// Максимальная длина строки текста
        /// </summary>
        public int TextLineMaxLength { get; private set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; private set; }

        public TextViewModel(string text, int textLineMaxLength)
        {
            TextLineMaxLength = textLineMaxLength;
            Text = text;
        }

        public TextViewModel(string text) : this(text, GetTextLineMaxLength())
        {
        }

        private static int GetTextLineMaxLength()
        {
            int textLineMaxLength;
            if (!int.TryParse(ConfigurationManager.AppSettings["TextLineMaxLength"], out textLineMaxLength))
            {
                textLineMaxLength = DefaultTextLineMaxLength;
            }
            return textLineMaxLength;
        }
    }
}