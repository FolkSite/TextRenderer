using System.Web.Mvc;
using TextRenderer.Core;
using TextRenderer.Models;

namespace TextRenderer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITextProvider _textProvider;

        public HomeController()
        {
            //note: тут можно поменять провайдера текста

            _textProvider = new HardCodedTextProvider();
            //_textProvider = new LocalFileTextProivider();
        }

        public ActionResult Index()
        {
            var text = _textProvider.Get();
            var model = new TextViewModel(text);
            return View(model);
        }
    }
}