using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using iPromoWeb.Models;
using Microsoft.EntityFrameworkCore;
using Amazon.Runtime;
using Microsoft.AspNetCore.Hosting;
using iPromoWeb.DAO;

namespace iPromoWeb.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private IHostingEnvironment _Env;
        public HomeController(IHostingEnvironment envrnmt, MySQLDBContext context)
        {
            _context = context;
            _Env = envrnmt; ;
        }

       
        public IActionResult Index()
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

        public async Task<IActionResult> QuotePage(int? QuoteID)
        {
            QuoteID = 58;
            if (QuoteID == null)
            {
                return NotFound();
            }

            var quote = await _context.Quote.SingleOrDefaultAsync(m => m.QuoteID == QuoteID);
            if (quote == null)
            {
                return NotFound();
            }
            return View(quote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuotePageEdit(int QuoteID, [Bind("QuoteID,QuoteNumber,QuoteStatusResultID,TPBackground,PromoFromDatetime,PromolToDatetime")] Quote quote)
        {
            if (QuoteID != quote.QuoteID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var stste = await new QuotePageDAO().StartWorkflowInstanceAsync(quote);
                    //AWSCredentials awsCredentials;
                    //if (_CredentialProfileStoreChain.TryGetAWSCredentials("local-test-profile", out awsCredentials))
                    //{
                    //}
                        _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }


        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
