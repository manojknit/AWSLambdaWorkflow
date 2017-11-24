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
        public IActionResult Index(int? id=32994, string role="RSM")
        {
            //var UserId = (id.HasValue && id.Value > 0) ? id.Value: 32994;
            //role = string.IsNullOrWhiteSpace(role) ? "RSM" : role;

            //var UserName = _context.SalesOrg.Where(w => w.UserID == UserId).Select(s => s.UserName).FirstOrDefault();
            //var roles = _context.SalesOrg.Where(w => w.UserID == UserId).Select(s => s.Title).ToList();

            //ViewBag.UserName = UserName;
            //ViewBag.Roles = roles;
            //ViewBag.Role = role;
            //ViewBag.UserId = UserId;

            //HttpContext.Session.SetInt32("UserId", UserId);
            //HttpContext.Session.SetString("UserName", UserName);
            //HttpContext.Session.SetString("Role", role);
            //HttpContext.Session.SetString("Roles", string.Join(',', roles));

            return View();
        }

        [HttpGet]
        [Route("Report/{id?}/{role?}")]
        public IActionResult Report(int? id, string role)
        {
            //var UserId = (id.HasValue && id.Value > 0) ? id.Value : 32994;
            //role = string.IsNullOrWhiteSpace(role) ? "RSM" : role;

            //var UserName = _context.SalesOrg.Where(w => w.UserID == UserId).Select(s => s.UserName).FirstOrDefault();
            //var roles = _context.SalesOrg.Where(w => w.UserID == UserId).Select(s => s.Title).ToList();

            //ViewBag.UserName = UserName;
            //ViewBag.Roles = roles;
            //ViewBag.Role = role;
            //ViewBag.UserId = UserId;

            //HttpContext.Session.SetInt32("UserId", UserId);
            //HttpContext.Session.SetString("UserName", UserName);
            //HttpContext.Session.SetString("Role", role);
            //HttpContext.Session.SetString("Roles", string.Join(',', roles));

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
