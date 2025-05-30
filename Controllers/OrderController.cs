using Housing.Data;
using Housing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Housing.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Payment()
        {
            var deliveryPeople = _context.DeliveryContacts.ToList();
            return View(new PaymentViewModel
            {
                DeliveryOptions = deliveryPeople
            });
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.DeliveryOptions = _context.DeliveryContacts.ToList();
                return View(model);
            }

            var userId = _userManager.GetUserId(User);

            var cartItems = _context.CartItems
                .Include(ci => ci.Furniture)
                .Where(ci => ci.SessionId == HttpContext.Session.Id)
                .ToList();


            foreach (var item in cartItems)
            {
                var order = new Order
                {
                    UserId = userId,
                    FurnitureId = item.Furniture.Id,
                    OrderDate = DateTime.Now
                };
                _context.Orders.Add(order);
            }

            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var userId = _userManager.GetUserId(User);

            var myOrders = await _context.Orders
                .Include(o => o.Furniture)
                .Where(o => o.UserId == userId)
                .ToListAsync();

            return View(myOrders);
        }
    }
}
