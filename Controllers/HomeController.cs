using Housing.Data;
using Microsoft.AspNetCore.Mvc;
using Housing.Models;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var featuredFurniture = _context.Furniture
            .OrderByDescending(f => f.DatePosted)
            .Take(5)
            .ToList();

        return View(featuredFurniture);
    }
}


