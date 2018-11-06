using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RummageSale.Data;
using RummageSale.Models;

namespace RummageSale.Controllers
{
    public class RummageUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RummageUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RummageUsers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RummageUser.Include(r => r.ApplicationUser).Include(r => r.Sale);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RummageUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rummageUser = await _context.RummageUser
                .Include(r => r.ApplicationUser)
                .Include(r => r.Sale)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (rummageUser == null)
            {
                return NotFound();
            }

            return View(rummageUser);
        }

        // GET: RummageUsers/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            ViewData["SaleId"] = new SelectList(_context.Set<Sale>(), "Id", "Id");
            return View();
        }

        // POST: RummageUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,Address,City,State,Zipcode,Phone,SaleId,ApplicationUserId")] RummageUser rummageUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rummageUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", rummageUser.ApplicationUserId);
            ViewData["SaleId"] = new SelectList(_context.Set<Sale>(), "Id", "Id", rummageUser.SaleId);
            return View(rummageUser);
        }

        // GET: RummageUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rummageUser = await _context.RummageUser.FindAsync(id);
            if (rummageUser == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", rummageUser.ApplicationUserId);
            ViewData["SaleId"] = new SelectList(_context.Set<Sale>(), "Id", "Id", rummageUser.SaleId);
            return View(rummageUser);
        }

        // POST: RummageUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,Address,City,State,Zipcode,Phone,SaleId,ApplicationUserId")] RummageUser rummageUser)
        {
            if (id != rummageUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rummageUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RummageUserExists(rummageUser.UserId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", rummageUser.ApplicationUserId);
            ViewData["SaleId"] = new SelectList(_context.Set<Sale>(), "Id", "Id", rummageUser.SaleId);
            return View(rummageUser);
        }

        // GET: RummageUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rummageUser = await _context.RummageUser
                .Include(r => r.ApplicationUser)
                .Include(r => r.Sale)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (rummageUser == null)
            {
                return NotFound();
            }

            return View(rummageUser);
        }

        // POST: RummageUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rummageUser = await _context.RummageUser.FindAsync(id);
            _context.RummageUser.Remove(rummageUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RummageUserExists(int id)
        {
            return _context.RummageUser.Any(e => e.UserId == id);
        }
    }
}
