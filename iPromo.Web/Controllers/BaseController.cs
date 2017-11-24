using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using iPromo.Entities;

namespace iPromo.Web.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!HttpContext.Session.GetInt32("UserId").HasValue)
            {
                SessionHelper.FillSession(HttpContext);
            }
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            ViewBag.Roles = HttpContext.Session.GetString("Roles").Split(new char[] { ',' }).ToList();
            base.OnActionExecuting(context);
        }
    }
}