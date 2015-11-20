namespace TextRenderer.Core
{
    /// <summary>
    /// Поставщик захардкоженного текста
    /// </summary>
    public class HardCodedTextProvider : ITextProvider
    {
        public string Get()
        {
            return "01234567890123456789 Репозиторий находится по ссылке https://github.com/imbeat/TextRenderer. Коротка ссылка https://ya.ru И еще ОченьДлинноеДлинноеПредлинноеСамоеДлинноеСлово.";
        }
    }
}