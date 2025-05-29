using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Housing.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Housing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Housing.Controllers
{
    public class FurnitureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public FurnitureController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Furniture
        public async Task<IActionResult> Index()
        {
            return View(await _context.Furniture.ToListAsync());
        }

        // GET: Furniture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furniture = await _context.Furniture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (furniture == null)
            {
                return NotFound();
            }

            return View(furniture);
        }

        // GET: Furniture/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new List<string> { "Sandalye", "Masa", "Koltuk", "Kitaplık", "Yatak", "Gardolap", "Portmanto", "Other", };
            ViewBag.Conditions = new List<string> { "Yeni Gibi", "İyi", "Orta", "Tamir Gerek" };
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                furniture.UserId = _userManager.GetUserId(User); // kullanıcı ID'si ata
                _context.Add(furniture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(furniture);
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furniture = await _context.Furniture.FindAsync(id);
            if (furniture == null)
            {
                return NotFound();
            }
            return View(furniture);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Category,Condition,Location,Price,Value,DatePosted,ImagePath")] Furniture furniture)

        {
            if (id != furniture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(furniture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FurnitureExists(furniture.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(furniture);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furniture = await _context.Furniture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (furniture == null)
            {
                return NotFound();
            }

            return View(furniture);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var furniture = await _context.Furniture.FindAsync(id);
            if (furniture != null)
            {
                _context.Furniture.Remove(furniture);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FurnitureExists(int id)
        {
            return _context.Furniture.Any(e => e.Id == id);
        }

        [Authorize]
        public async Task<IActionResult> MyItems()
        {
            var userId = _userManager.GetUserId(User);
            var myItems = await _context.Furniture
                .Where(f => f.UserId == userId)
                .ToListAsync();

            return View(myItems);
        }

    }
}
