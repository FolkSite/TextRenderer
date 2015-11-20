using System;
using System.IO;
using System.Web.Hosting;

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

    /// <summary>
    /// Провайдер текста из локального файла
    /// </summary>
    public class LocalFileTextProivider : ITextProvider
    {
        public const string FileName = @"TestText.txt";

        public string Get()
        {
            var path = HostingEnvironment.MapPath(@"~/App_Data/" + FileName);
            return File.ReadAllText(path);
        }
    }
}