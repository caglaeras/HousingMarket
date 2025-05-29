// Controllers/NotificationController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Housing.Models;

namespace Housing.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            // Dummy bildirimler
            var notifications = new List<string>
            {
                "Daha önce sipariş verdiğiniz 'Beyaz Çalışma Masası' için bir değerlendirme bırakabilirsiniz.",
                "'Kırmızı Kanepe' adlı ürününüzle ilgilenen bir kullanıcı var.",
                "Yüklediğiniz 'Ahşap Kitaplık' ürünü favorilere eklendi."
            };

            return View(notifications);
        }
    }
}
