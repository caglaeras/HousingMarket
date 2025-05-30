using Microsoft.AspNetCore.Mvc;
using Housing.Data;
using Housing.Models;

namespace Housing.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string FavoritesSessionKey = "FavoriteItems";

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var favorites = HttpContext.Session.GetString(FavoritesSessionKey);
            List<Furniture> favoriteItems = new();

            if (!string.IsNullOrEmpty(favorites))
            {
                var ids = favorites.Split(',').Select(int.Parse).ToList();
                favoriteItems = _context.Furniture.Where(f => ids.Contains(f.Id)).ToList();
            }

            return View(favoriteItems);
        }

        [HttpPost]
        public IActionResult AddToFavorites(int id)
        {
            var favorites = HttpContext.Session.GetString(FavoritesSessionKey);
            List<string> ids = string.IsNullOrEmpty(favorites) ? new List<string>() : favorites.Split(',').ToList();

            if (!ids.Contains(id.ToString()))
            {
                ids.Add(id.ToString());
                HttpContext.Session.SetString(FavoritesSessionKey, string.Join(",", ids));
            }

            return RedirectToAction("Index"); //  favoriler sayfasına yönlendir
        }


        public IActionResult RemoveFromFavorites(int id)
        {
            var favorites = HttpContext.Session.GetString(FavoritesSessionKey);
            if (!string.IsNullOrEmpty(favorites))
            {
                var ids = favorites.Split(',').ToList();
                ids.Remove(id.ToString());
                HttpContext.Session.SetString(FavoritesSessionKey, string.Join(",", ids));
            }

            return RedirectToAction("Index");
        }
    }
}
