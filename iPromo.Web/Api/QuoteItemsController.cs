using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iPromo.Entities;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;

namespace iPromo.Web.Api
{
    [Produces("application/json")]
    [Route("api/QuoteItems")]
    public class QuoteItemsController : Controller
    {
        private readonly iPromoDataContext _context;

        public QuoteItemsController(iPromoDataContext context)
        {
            _context = context;
        }

        // GET: api/QuoteItems
        [HttpGet]
        [Route("{id?}/{role?}/{quoteNumber?}")]
        public IEnumerable<QuoteItem> GetQuoteItem(long? id, string role, string quoteNumber)
        {

            if (string.IsNullOrWhiteSpace(quoteNumber))
            {
                var items = new List<QuoteItem>();
                //items.Add(new QuoteItem());
                //items.Add(new QuoteItem());
                return items;
            }

            var quoteItems = (from qi in _context.QuoteItem
                              join q in _context.Quote on qi.QuoteID equals q.QuoteID
                              where q.QuoteNumber == quoteNumber
                              select qi);

            return quoteItems;
        }

        // GET: api/QuoteItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuoteItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quoteItem = await _context.QuoteItem.SingleOrDefaultAsync(m => m.QuoteItemID == id);

            if (quoteItem == null)
            {
                return NotFound();
            }

            return Ok(quoteItem);
        }

        // PUT: api/QuoteItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuoteItem([FromRoute] long id, [FromBody] QuoteItem quoteItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quoteItem.QuoteItemID)
            {
                return BadRequest();
            }

            _context.Entry(quoteItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        [Route("approval/{id?}/{role?}/{quoteNumber?}")]
        public async Task<IActionResult> PostQuoteItems(long? id, string role, string quoteNumber, [FromBody] List<QuoteItem> quoteItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var quote = await _context.Quote.SingleOrDefaultAsync(m => m.QuoteNumber == quoteNumber);
            if (quote == null)
            {
                return NotFound();
            }
            var nextStatus = StaticItems.GetNextStatus(quote.QuoteStatusLevelID, quote.QuoteStatusResultID);

            quote.QuoteStatusLevelID = nextStatus.Item1;
            quote.QuoteStatusResultID = nextStatus.Item2;

            switch (role)
            {
                case "RSM":
                    if (quote.QuoteStatusResultID==14)
                    {
                        quote.WinLossUserID = (int) id.Value;
                        quote.WinLossDateTime = DateTime.Now;
                    }
                    break;
                case "PM":
                    quote.PMActualApprovedByUserID = (int)id.Value;
                    quote.PMApprovedByUserID = (int)id.Value;
                    quote.PMApprovedDateTime = DateTime.Now;
                    
                    break;
                case "POE":
                    quote.PEActualApprovedByUserId = (int)id.Value;
                    quote.PEApprovedByUserId = (int)id.Value;
                    quote.PEApprovedDateTime = DateTime.Now;
                    break;
                case "VP FINANCE":
                    quote.VPFinanceActualApprovedByUserID = (int)id.Value;
                    quote.VPFinanceApprovedByUserID = (int)id.Value;
                    quote.VPFinanceApprovedDateTime = DateTime.Now;
                    break;
            }

            _context.Entry(quote).State = EntityState.Modified;

            foreach (var quoteItem in quoteItems)
            {
                if (role == "PM")
                {
                    quoteItem.WinNetPrice = quoteItem.PMApprovedPrice;
                    quoteItem.WinQuantity = quoteItem.RequestedQuantity;
                }
                _context.Entry(quoteItem).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteItemExists(quoteItem.QuoteItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            //API CALL ToDo
            if (role == "PM")
            {
                string pmApprovaluri = "https://wyunsq1ccf.execute-api.us-east-1.amazonaws.com/respond/approve?taskToken=" + quote.Token + "&quoteid=" + quote.QuoteID;
                string output = DoAPICallToApprove(pmApprovaluri);
            }

            return Ok(new { success = true });// CreatedAtAction("GetQuoteItem", new { id = quoteItem.QuoteItemID }, quoteItem);
        }

        private string DoAPICallToApprove(string URL)
        {
            try
            {
                string output = string.Empty;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    
                        output = dataObjects.ToString();
                    
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("accept/{id?}/{role?}/{quoteNumber?}")]
        public async Task<IActionResult> AcceptQuoteItems(long? id, string role, string quoteNumber, [FromBody] List<QuoteItem> quoteItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var quote = await _context.Quote.SingleOrDefaultAsync(m => m.QuoteNumber == quoteNumber);
            if (quote == null)
            {
                return NotFound();
            }
            var nextStatus = StaticItems.GetNextStatus(quote.QuoteStatusLevelID, quote.QuoteStatusResultID);

            quote.QuoteStatusLevelID = nextStatus.Item1;
            quote.QuoteStatusResultID = nextStatus.Item2;
            quote.WinLossDateTime = DateTime.Now;
            quote.WinLossUserID = (int) id.Value;
            _context.Entry(quote).State = EntityState.Modified;

            foreach (var quoteItem in quoteItems)
            {
                _context.Entry(quoteItem).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteItemExists(quoteItem.QuoteItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(new { success = true });// CreatedAtAction("GetQuoteItem", new { id = quoteItem.QuoteItemID }, quoteItem);
        }
        // POST: api/QuoteItems
        [HttpPost]
        public async Task<IActionResult> PostQuoteItem([FromBody] QuoteItem quoteItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuoteItem.Add(quoteItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuoteItem", new { id = quoteItem.QuoteItemID }, quoteItem);
        }

        // DELETE: api/QuoteItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuoteItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quoteItem = await _context.QuoteItem.SingleOrDefaultAsync(m => m.QuoteItemID == id);
            if (quoteItem == null)
            {
                return NotFound();
            }

            _context.QuoteItem.Remove(quoteItem);
            await _context.SaveChangesAsync();

            return Ok(quoteItem);
        }

        private bool QuoteItemExists(long id)
        {
            return _context.QuoteItem.Any(e => e.QuoteItemID == id);
        }
    }
}