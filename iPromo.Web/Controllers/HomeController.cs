using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iPromo.Web.Models;
using iPromo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace iPromo.Web.Controllers
{
    [Route("Home")]
    [Route("")]
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly iPromoDataContext _context;
        public HomeController(iPromoDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        [Route("Index/{id?}/{role?}")]
        //[ResponseCache(VaryByHeader = "User-Agent", Duration = 1)]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index(int? id=32994, string role="RSM")
        {
            
            //ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            if (HttpContext.Session.GetString("Role") != role)
            {
                var userid = HttpContext.Session.GetInt32("UserId") ?? 0;
                var roles = _context.SalesOrg.Where(w => w.UserID == userid).Select(s => s.Title).ToList<string>();
                if (roles.IndexOf(role) > -1)
                {
                    ViewBag.Role = role;
                    HttpContext.Session.SetString("Role", role);

                }
            }
            

            return View();
        }

        [HttpGet]
        [Route("Report/{id?}/{role?}")]
        public IActionResult Report(int? id, string role)
        {

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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
