using iPromo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iPromo.Web
{
    public static class SessionHelper
    {
        public static void FillSession(HttpContext httpcontext)
        {
            iPromoDataContext context = httpcontext.RequestServices.GetService(typeof(iPromoDataContext)) as iPromoDataContext;
            int? id = Convert.ToInt32(httpcontext.Features.Get<IRoutingFeature>().RouteData.Values["id"]);
            string role = Convert.ToString(httpcontext.Features.Get<IRoutingFeature>().RouteData.Values["role"]);
            var userId = (id.HasValue && id.Value > 0) ? id.Value : 0;
            role = string.IsNullOrWhiteSpace(role) ? "RSM" : role;

            if (userId == 0)
            {
                string email = httpcontext.User.Identity.Name;
                userId = context.SalesOrg.Where(w => w.ADUserID == email).Select(s => s.UserID).FirstOrDefault();
            }
            var userName = context.SalesOrg.Where(w => w.UserID == userId).Select(s => s.UserName).FirstOrDefault();
            var roles = context.SalesOrg.Where(w => w.UserID == userId).Select(s => s.Title).ToList();

            httpcontext.Session.SetInt32("UserId", userId);
            httpcontext.Session.SetString("UserName", userName);
            httpcontext.Session.SetString("Role", role);
            httpcontext.Session.SetString("Roles", string.Join(',', roles));
        }
    }
}
