using System;

namespace TextRenderer.Core
{
    /// <summary>
    /// Поставщик исходного текста
    /// </summary>
    public interface ITextProvider
    {
        /// <summary>
        /// Возращает текст
        /// </summary>
        string Get();
    }
}