using Microsoft.AspNetCore.Mvc;

namespace Housing.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
