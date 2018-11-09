using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RummageSale.Data;
using RummageSale.Models;

namespace RummageSale.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CategoriesController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category_1.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(bool? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category_1
                .FirstOrDefaultAsync(m => m.Electronics == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Electronics,Furniture,Toys,Clothings,PersonalCare,Media")] Category category)
        {
            if (ModelState.IsValid)
            {
               // var saleID = sale.UserId.ToString();
                var user = _userManager.GetUserId(HttpContext.User);
                var selectUser = _context.RummageUser.Where(r => r.ApplicationUserId == user).SingleOrDefault();
                category.SaleId = selectUser.UserId.ToString();
                _context.Category.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(bool? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category_1.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(bool? id, [Bind("Electronics,Furniture,Toys,Clothings,PersonalCare,Media")] Category category)
        {
            if (id != category.Electronics)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Electronics))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(bool? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category_1
                .FirstOrDefaultAsync(m => m.Electronics == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(bool? id)
        {
            var category = await _context.Category_1.FindAsync(id);
            _context.Category_1.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(bool? id)
        {
            return _context.Category_1.Any(e => e.Electronics == id);
        }
    }
}
