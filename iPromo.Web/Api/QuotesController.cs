using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iPromo.Entities;

namespace iPromo.Web.Api
{
    [Produces("application/json")]
    [Route("api/Quotes")]
    public class QuotesController : Controller
    {
        private readonly iPromoDataContext _context;

        public QuotesController(iPromoDataContext context)
        {
            _context = context;
        }
        // GET: api/Qutoes/Products/32994/RSM/820003
        [HttpGet]
        [Route("products/{id?}/{role?}/{quoteNumber?}/{keyword?}")]
        public IEnumerable<ProductItem> GetProducts(long? id, string role, string quoteNumber, string keyword)
        {
            var result = new List<ProductItem>();
            //if (string.IsNullOrWhiteSpace(quoteNumber))
            //{
            //    var items = new List<mtListPrice>();
            //    return items;
            //}
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {

                //TODO: SQL Injection warning!!!
                //TODO: need to find out a way to work with parameters or use linq!
                var query = @"SELECT distinct
                                        p.ProductID as ProductNumber
                                        ,p.ProductLine as ProductLine
                                        ,p.Description as Description
                                        ,p.MemoryCapacityGroup as MemoryCapacity
                                        ,pr.Prc_Lst_Su as ListPrice
                                        FROM mtListPrice pr
                                        inner join mtproduct p on pr.Material = p.ProductID
                                        where p.ProductID  like @keyword
                                        ";
                var val = string.Format("'%{0}%'", keyword);
                command.CommandText = query.Replace("@keyword", val);
                //MySql.Data.MySqlClient.MySqlParameter param = new MySql.Data.MySqlClient.MySqlParameter();
                //param.ParameterName = "@keyword";
                //param.Value = string.Format("%{0}%", keyword);
                //command.Parameters.Insert(1, keyword);
                //command.Parameters[0].ParameterName = "@keyword";
                //command.Parameters["@keyword"].Value = keyword;
                _context.Database.OpenConnection();
                //var ss = command.ExecuteScalar();

                using (var r = command.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var ProductNumber = r.GetFieldValue<string>(0);
                        var oProductLine = r.GetValue(1);
                        var ProductLine = oProductLine == DBNull.Value ? string.Empty : oProductLine.ToString();

                        var oDescription = r.GetValue(2);
                        var Description = oDescription == DBNull.Value ? string.Empty : oDescription.ToString();

                        var oMemoryCapacity = r.GetValue(3);
                        var MemoryCapacity = oMemoryCapacity == DBNull.Value ? string.Empty : oMemoryCapacity.ToString();

                        var oListPrice = r.GetValue(4);
                        var ListPrice = oListPrice == DBNull.Value ? string.Empty : oListPrice.ToString();

                        var item = new ProductItem();
                        item.ProductNumber = ProductNumber;
                        item.ProductLine = ProductLine;
                        item.Description = Description;
                        item.MemoryCapacity = MemoryCapacity;
                        item.ListPrice = ListPrice;
                        result.Add(item);

                    }
                    // do something with result
                }
            }
            //var products = (from p in _context.mtListPrice
            //                where p.Material.Contains(keyword)
            //                group p by new { p.Material, p.Prc_Lst_Su } into g
            //                select new { g.Key.Material, g.Key.Prc_Lst_Su }).OrderByDescending(od => od.Prc_Lst_Su).Take(100).ToList();

            //var result = products.Select(s =>
            //{
            //    var item = new mtListPrice();
            //    item.Material = s.Material;
            //    item.Prc_Lst_Su = s.Prc_Lst_Su;
            //    return item;
            //}).ToList();

            return result;
        }
        // GET: api/Quotes
        [HttpGet]
        [Route("worklist/{id}/{role}")]
        public IEnumerable<Quote> GetWorkList([FromRoute] string role, [FromRoute] long id)
        {
            var inq = StaticItems.QuoteStatusResult.Where(w => w.Value.ToLower() == "in q").Select(f => f.Key).FirstOrDefault();
            var roleId = StaticItems.QuoteStatusLevel.Where(w => w.Value.ToLower() == role.ToLower()).Select(f => f.Key).FirstOrDefault();
            if (role.ToLower() == "rsm" || role.ToLower() == "external r")
            {
                var quotes = (from q in _context.Quote
                              where q.QuoteStatusLevelID == roleId && (q.QuoteStatusResultID == 1 || q.QuoteStatusResultID == 12 || q.QuoteStatusResultID == 14 || q.QuoteStatusResultID == 15 )  && q.SubmittedByUserID == id
                              orderby q.LastModifiedDatetime descending
                              select q).ToList();
                return quotes;
            }
            else if (role.ToLower() == "pm" || role.ToLower() == "vp finance" || role.ToLower() == "poe")
            {
                var quotes = (from q in _context.Quote
                              where q.QuoteStatusLevelID == roleId && q.QuoteStatusResultID == inq
                              orderby q.LastModifiedDatetime descending
                              select q).ToList();
                return quotes;
            }
            else
            {
                return new List<Quote>();
            }
        }

        [HttpGet]
        [Route("report/{id}/{role}")]
        public IEnumerable<Quote> GetReport([FromRoute] string role, [FromRoute] long id)
        {
            var quotes = (from q in _context.Quote
                          select q).ToList();
            return quotes;
        }

        // GET: api/Quotes
        [HttpGet]
        public IEnumerable<Quote> GetQuote()
        {
            return _context.Quote;
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuote([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quote = await _context.Quote.SingleOrDefaultAsync(m => m.QuoteID == id);

            if (quote == null)
            {
                return NotFound();
            }

            return Ok(quote);
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote([FromRoute] long id, [FromBody] Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quote.QuoteID)
            {
                return BadRequest();
            }

            _context.Entry(quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
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

        // POST: api/Quotes
        [HttpPost]
        [Route("{id}/{userName}/{role}/{quoteNumber?}")]
        public async Task<IActionResult> PostQuote(string id, string userName, string role, string quoteNumber, [FromBody] Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrWhiteSpace(quoteNumber))
            {
                long maxQuote = _context.Quote.Max(m => m.QuoteID) + 1;
                quote.QuoteNumber = string.Format("000{0}", maxQuote);
                quote.CreatedByUserID = Convert.ToInt32(id);
                quote.SubmittedByUserID = Convert.ToInt32(id);
                quote.CreatedDateTime = DateTime.Now;
                quote.LastModifiedDatetime = DateTime.Now;
                if (!string.IsNullOrWhiteSpace(quote.PublicComments))
                    quote.PublicComments = String.Format("({0}): {1} - {2}<br />", DateTime.Now, userName, quote.PublicComments);
                _context.Quote.Add(quote);
            }
            else
            {
                var dbQuote = _context.Quote.FirstOrDefault(q => q.QuoteNumber == quoteNumber);
                dbQuote.NeedPriceApprovedBy = quote.NeedPriceApprovedBy;
                dbQuote.PlanningAccountNumber = quote.PlanningAccountNumber;
                dbQuote.TPBackground = quote.TPBackground;
                dbQuote.AccountManagerID = quote.AccountManagerID;
                dbQuote.EndCustomerID = quote.EndCustomerID;
                dbQuote.EndUser = quote.EndUser;
                dbQuote.PromoFromDatetime = quote.PromoFromDatetime;
                dbQuote.PromolToDatetime = quote.PromolToDatetime;
                dbQuote.QuoteStatusLevelID = quote.QuoteStatusLevelID;
                dbQuote.QuoteStatusResultID = quote.QuoteStatusResultID;
                dbQuote.CreatedByUserID = quote.CreatedByUserID;
                dbQuote.SubmittedByUserID = quote.SubmittedByUserID;
                dbQuote.LastModifiedDatetime = DateTime.Now;
                if (!string.IsNullOrWhiteSpace(quote.PublicComments))
                    dbQuote.PublicComments += String.Format("({0}): {1} - {2}<br />", DateTime.Now, userName, quote.PublicComments);

                _context.Entry(dbQuote).State = EntityState.Modified;
                dbQuote.QuoteItem = new List<QuoteItem>();
                foreach (var qi in quote.QuoteItem)
                {
                    dbQuote.QuoteItem.Add(qi);
                    _context.Entry(qi).State = qi.QuoteItemID > 0 ? EntityState.Modified : EntityState.Added;
                }
                _context.Quote.Update(dbQuote);
            }
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetQuote", new { id = quote.QuoteID }, quote);
            return new OkObjectResult(new { id = quote.QuoteID, QuoteNumber = quote.QuoteNumber });
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quote = await _context.Quote.SingleOrDefaultAsync(m => m.QuoteID == id);
            if (quote == null)
            {
                return NotFound();
            }

            _context.Quote.Remove(quote);
            await _context.SaveChangesAsync();

            return Ok(quote);
        }

        private bool QuoteExists(long id)
        {
            return _context.Quote.Any(e => e.QuoteID == id);
        }

        [HttpGet]
        [Route("getcustomer/{role}/{srchText}")]
        public IEnumerable<mtCustomer> GetListOfCustomers([FromRoute] string role, [FromRoute] string srchText)
        {
            List<mtCustomer> soldToCustomerList = new List<mtCustomer>();
            if (role.ToLower() == "rsm")
            {
                soldToCustomerList = (from q in _context.mtCustomer
                                      where q.CustomerNumber.Contains(srchText)
                                      select q).ToList();
                return soldToCustomerList;
            }
            else
            {
                return new List<mtCustomer>();
            }
        }

        [HttpGet]
        [Route("gettier2customer/{role}/{srchText}")]
        public IEnumerable<mtCustomer> GetListOfTier2Customers([FromRoute] string role, [FromRoute] string srchText)
        {
            List<mtCustomer> tier2CustomerList = new List<mtCustomer>();
            if (role.ToLower() == "rsm")
            {
                tier2CustomerList = (from q in _context.mtCustomer
                                     where q.CustomerNumber.Contains(srchText)
                                     select q).ToList();
                return tier2CustomerList;
            }
            else
            {
                return new List<mtCustomer>();
            }
        }

        [HttpGet]
        [Route("getendcustomer/{role}/{srchText}")]
        public IEnumerable<mtCustomer> GetListOfEndCustomers([FromRoute] string role, [FromRoute] string srchText)
        {
            List<mtCustomer> endCustomerList = new List<mtCustomer>();
            if (role.ToLower() == "rsm")
            {
                endCustomerList = (from q in _context.mtCustomer
                                   where q.CustomerNumber.Contains(srchText)
                                   select q).ToList();
                return endCustomerList;
            }
            else
            {
                return new List<mtCustomer>();
            }
        }

        [HttpGet]
        [Route("getaccountmanager")]
        public IEnumerable<SalesOrg> GetListOfAccountManager()
        {
            List<SalesOrg> accountmgrList = new List<SalesOrg>();
            accountmgrList = (from q in _context.SalesOrg
                              group q by new { q.UserID, q.UserName }
                  into accManager
                              select accManager.FirstOrDefault()).ToList();
            return accountmgrList;
        }
    }
}