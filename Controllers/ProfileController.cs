using Housing.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class ProfileController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public ProfileController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult MyItems()
    {
        var userId = _userManager.GetUserId(User);
        var myItems = _context.Furniture.Where(f => f.UserId == userId).ToList();
        return View(myItems);
    }
}
