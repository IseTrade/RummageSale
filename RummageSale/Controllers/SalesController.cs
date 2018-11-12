using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RummageSale.Data;
using RummageSale.Models;

namespace RummageSale.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHostingEnvironment he;

        public SalesController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IHostingEnvironment e)
        {
            _userManager = userManager;
            he = e;
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sale_1.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale_1.FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Email,Address,City,State,Zipcode,Phone,StartDate,EndDate,RescheduleStartDate,RescheduleEndDate,Description,PriceRange,CatId,Electronics,Furniture,Toys,Clothings")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                // var saleID = sale.UserId.ToString();
                var user = _userManager.GetUserId(HttpContext.User);
                var selectUser = _context.RummageUser.Where(r => r.ApplicationUserId == user).SingleOrDefault();
                sale.UserId = selectUser.UserId;
                _context.Sale.Add(sale);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sale);
        }

        //filter by zipcode
        public IActionResult Index2()
        {

            var user = _userManager.GetUserId(HttpContext.User);
            var selectUser = _context.RummageUser.Where(r => r.ApplicationUserId == user).SingleOrDefault();
            List<Sale> sale = _context.Sale.Where(s => s.Zipcode == selectUser.Zipcode).ToList();
            //var userZipCode = _context.RummageUser.Where(z => z.Zipcode == sale.Zipcode).ToList();
            return View(sale);

            //rename zipCode = rummageuserzipcode
            //switch sale and rummage user

        }

        //filter by cat
        public IActionResult Filterbycat()
        {
            var catId = _userManager.GetUserId(HttpContext.User);
            var cat = _context.Category.Where(c => (c.Id).ToString() == catId).SingleOrDefault();
            var category = _context.Category.Where(c => c.Media == cat.Media && c.PersonalCare == cat.PersonalCare &&
            c.Clothings == cat.Clothings && c.Electronics == cat.Electronics && c.Furniture == cat.Furniture && c.Toys == cat.Toys).ToList();
            return View(category);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Description,RescheduleStartDate,RescheduleEndDate,CatId")] Sale sale)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(sale);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(sale);
        //}

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale_1.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Description,RescheduleStartDate,RescheduleEndDate,Electronics,Furniture,Toys,Clothings,CatId")] Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.Id))
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
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sale_1.FindAsync(id);
            _context.Sale_1.Remove(sale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return _context.Sale_1.Any(e => e.Id == id);
        }
        [HttpGet]
        public IActionResult UploadPicture()
        {
            return View();

        }

        [HttpPost]
        public IActionResult UploadPicture(IFormFile pic, int? id)
        {
            //if the picture does not exist move on
            if (pic == null)
            {
                return View();
            }
            else
            {
                //get the full path to the file
                var fullPath = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));

                //get the filename with extension
                var fileName = pic.FileName;
                pic.CopyTo(new FileStream(fullPath, FileMode.Create));

                //string userid = User.FindFirstValue(ClaimTypes.NameIdentifier); original
                string userId = _userManager.GetUserId(HttpContext.User);

                var sale = _context.Sale.Where(m => m.RummageUser.ApplicationUserId == userId).FirstOrDefault();
                sale.Picture = fileName; //store in database Picture field

                _context.Update(sale);
                _context.SaveChangesAsync(); //save to database

                //Configure information for the view page
                ViewData["FileName"] = fileName.Replace(".jpg", "").Replace(".png", ""); //take filename and rip out extension
                ViewData["FileLocation"] = "/" + Path.GetFileName(pic.FileName);//wwwroot = http://....:####/
            }

            return View();
        }
    }
}
