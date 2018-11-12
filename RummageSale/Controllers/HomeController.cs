using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RummageSale.Data;
using RummageSale.Models;

namespace RummageSale.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        /// <summary>
        /// Rummage Sale Home Page /index.cshtml
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.Address = _context.Sale.Select(s => s.Address).FirstOrDefault();
            ViewBag.Zipcode = _context.Sale.Select(s => s.Zipcode).FirstOrDefault();


            //Test - Failed
            //Attempted to obtain all address/zip code from Sales table to populate for Google Maps API
            //ViewBag.SalesAddressList = _context.Sale.Select(s => s.Address).ToArray();
            //ViewBag.SalesZipCodeList = _context.Sale.Select(s => s.Zipcode).ToArray();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
