using Microsoft.AspNetCore.Mvc;
using Housing.Data;
using Housing.Models;

namespace Housing.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "CartItems";

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cartIds = HttpContext.Session.GetString(CartSessionKey);
            List<Furniture> cartItems = new();
            List<Furniture> suggestions = new();

            if (!string.IsNullOrEmpty(cartIds))
            {
                var ids = cartIds.Split(',').Select(id => int.Parse(id)).ToList();
                cartItems = _context.Furniture.Where(f => ids.Contains(f.Id)).ToList();

                var cartCategories = cartItems
                    .Where(f => !string.IsNullOrEmpty(f.Category))
                    .Select(f => f.Category)
                    .Distinct()
                    .ToList();

                suggestions = _context.Furniture
                    .Where(f => cartCategories.Contains(f.Category) && !ids.Contains(f.Id))
                    .OrderBy(f => Guid.NewGuid()) // Randomize
                    .Take(4)
                    .ToList();
            }

            var model = new CartViewModel
            {
                CartItems = cartItems,
                Suggestions = suggestions
            };

            return View(model);
        }

        // Sepete Ekle + Cart
        public IActionResult AddToCart(int id)
        {
            var cart = HttpContext.Session.GetString(CartSessionKey);
            List<string> ids = string.IsNullOrEmpty(cart) ? new List<string>() : cart.Split(',').ToList();

            if (!ids.Contains(id.ToString()))
            {
                ids.Add(id.ToString());
                HttpContext.Session.SetString(CartSessionKey, string.Join(",", ids));
            }

            // Sepete sonrası Cart sayfası
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetString(CartSessionKey);
            if (!string.IsNullOrEmpty(cart))
            {
                var ids = cart.Split(',').ToList();
                ids.Remove(id.ToString());
                HttpContext.Session.SetString(CartSessionKey, string.Join(",", ids));
            }

            return RedirectToAction("Index");
        }
    }
}
