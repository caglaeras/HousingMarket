using Housing.Data;
using Housing.Models;
using Microsoft.AspNetCore.Mvc;

// Add using statement if not present
using Microsoft.EntityFrameworkCore;

public class DeliveryContactController : Controller
{
    private readonly ApplicationDbContext _context;

    public DeliveryContactController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var contacts = _context.DeliveryContacts.ToList();
        return View(contacts);
    }

    // ---------- CREATE ----------
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(DeliveryContact contact)
    {
        if (ModelState.IsValid)
        {
            _context.DeliveryContacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(contact);
    }

    // ---------- EDIT ----------
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var contact = _context.DeliveryContacts.Find(id);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

    [HttpPost]
    public IActionResult Edit(DeliveryContact contact)
    {
        if (ModelState.IsValid)
        {
            _context.Update(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(contact);
    }

    // ---------- DELETE ----------
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var contact = _context.DeliveryContacts.Find(id);
        if (contact != null)
        {
            _context.DeliveryContacts.Remove(contact);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}
