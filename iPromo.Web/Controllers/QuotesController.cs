using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iPromo.Entities;
using Microsoft.AspNetCore.Authorization;

namespace iPromo.Web.Controllers
{
    [Route("Quotes")]
    [Authorize]
    public class QuotesController : BaseController
    {
        private readonly iPromoDataContext _context;

        public QuotesController(iPromoDataContext context)
        {
            _context = context;
        }

        // GET: Quotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quote.ToListAsync());
        }

        // GET: Quotes/Details/5
        [HttpGet]
        [Route("Details/{id?}/{role?}/{quoteNumber?}")]
        public async Task<IActionResult> Details(long? id, string role, string quoteNumber)
        {
            ViewBag.QuoteNumber = quoteNumber;
            if (id == null || string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(quoteNumber))
            {
                return NotFound();
            }

            var quote = await _context.Quote
                .SingleOrDefaultAsync(m => m.QuoteNumber == quoteNumber);
            if (quote == null)
            {
                return NotFound();
            }

            

            return View("Approval",quote);
        }
        [HttpGet]
        [Route("ReadOnly/{id?}/{role?}/{quoteNumber?}")]
        public async Task<IActionResult> ReadOnly(long? id, string role, string quoteNumber)
        {
            ViewBag.QuoteNumber = quoteNumber;
            if (id == null || string.IsNullOrWhiteSpace(role) || string.IsNullOrWhiteSpace(quoteNumber))
            {
                return NotFound();
            }

            var quote = await _context.Quote
                .SingleOrDefaultAsync(m => m.QuoteNumber == quoteNumber);
            if (quote == null)
            {
                return NotFound();
            }



            return View("ReadOnly", quote);
        }
        [HttpGet]
        [Route("Create/{id?}/{role?}/{quoteNumber?}")]
        // GET: Quotes/Create
        public IActionResult Create(long? id, string role, string quoteNumber)
        {
            if (id == null || string.IsNullOrWhiteSpace(role))
            {
                return NotFound();
            }
            var model = new iPromo.Entities.Quote();
            if (string.IsNullOrWhiteSpace(quoteNumber))
            {
                model.QuoteStatusResultID = 12;
                model.QuoteStatusLevelID = 2;
                model.SubmitDatetime = DateTime.Now;
                model.NeedPriceApprovedBy = DateTime.Now.AddDays(3);//TODO?: Hardcode value, need from configuration?
                model.QuoteNumber = "Auto Assigned";
            }
            else
            {
                model = _context.Quote.FirstOrDefault(f => f.QuoteNumber == quoteNumber);
                ViewBag.SoldToName = _context.mtCustomer.FirstOrDefault(f => f.CustomerNumber == model.PlanningAccountNumber).Customer_Desc;
                ViewBag.Tier2CustomerName = _context.mtCustomer.FirstOrDefault(f => f.CustomerNumber == model.EndCustomerID).Customer_Desc;
                ViewBag.EndCustomerName = _context.mtCustomer.FirstOrDefault(f => f.CustomerNumber == model.EndUser).Customer_Desc;
                ViewBag.Currency = string.IsNullOrEmpty(model.Currency) ? null : model.Currency;
                ViewBag.AccountManagerName = _context.SalesOrg.FirstOrDefault(f => f.UserID == model.AccountManagerID).UserName;
                ViewBag.QuoteNumber = model.QuoteNumber;
            }
            return View(model);
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuoteID,QuoteNumber,ValidTill,QuoteTypeID,QuoteStatusLevelID,QuoteStatusResultID,RSMSalesOrgUserId,PlanningAccountNumber,EndCustomerID,EndUser,ObjectiveCode,TacticCode,ObjectiveTypeCode,Comments,PromoAllOrNothing,NeedPriceApprovedBy,PromoFromDatetime,PromolToDatetime,TPBackground,SubmitDatetime,SubmittedByUserID,CreatedByUserID,CreatedDateTime,LastModifiedByUserID,LastModifiedDatetime,QuoteExpirationDate,RejRetReason,NonPriceProtectionAccount,SerialNumber,PublicComments,PrivateComments,AccountManagerID,ExpiryNotificationDate,Currency,QuoteSubTypeID,CRM_Status,CRM_Messages,PromoType,FundPlan,Fund,RSMApprovedByUserID,RSMActualApprovedByUserID,RSMApprovedDateTime,RSDApprovedByUserID,RSDActualApprovedByUserID,RSDApprovedDateTime,BidDeskApprovedByUserID,BidDeskActualApprovedByUserID,BidDeskApprovedDateTime,MMApprovedByUserID,MMActualApprovedByUserID,MMApprovedDateTime,PMApprovedByUserID,PMActualApprovedByUserID,PMApprovedDateTime,VPSalesApprovedByUserID,VPSalesActualApprovedByUserID,VPSalesApprovedDateTime,VPFinanceApprovedByUserID,VPFinanceActualApprovedByUserID,VPFinanceApprovedDateTime,IsNotAllIn,IsCostAdder,FulfillmentFileInfoID,FulfillmentSheet,CreatedByActualUserId,SubmittedByActualUserId,CanceledByUserID,CanceledDateTime,CancelReason,SecondExpiryNotificationDate,FinalExpiryNotificationDate,LossNotificationDate,TotalValue,IsFIAll,IsDistributeAcrossAllSKU,RSDApproverUserID,RMMApprovedByUserID,RMMApprovedDateTime,RMMActualApprovedByUserID,MDApprovedByUserID,MDApprovedDateTime,MDActualApprovedByUserID,RFMApprovedByUserID,RFMApprovedDateTime,RFMActualApprovedByUserID,RFCApprovedByUserID,RFCApprovedDateTime,RFCActualApprovedByUserID,ExchangeRate,TemplateID,IgnoreTemplate,ReferenceNumber,PromoID,PayToT2,Application,Project,ExistingProject,ExpectedShipDate,WinLossDateTime,WinLossUserID,RevenueApporvalDate,InQWinlossDate,BillTo,ShipTo,IsDealReg,CommentforPDF,IsQuoteCreateFromCRM,PEApprovedByUserId,PEActualApprovedByUserId,PEApprovedDateTime,Action,CustomerQuarter,CustomerYear,FinalReviewerActualApproverUserID,FinalReviewerApprovalDate,FinalReviewerApproverUserID,PricingTerm,VolumeCommitment,IsQuoteSent,IsApproveFloorFlow")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quote.SingleOrDefaultAsync(m => m.QuoteID == id);
            if (quote == null)
            {
                return NotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("QuoteID,QuoteNumber,ValidTill,QuoteTypeID,QuoteStatusLevelID,QuoteStatusResultID,RSMSalesOrgUserId,PlanningAccountNumber,EndCustomerID,EndUser,ObjectiveCode,TacticCode,ObjectiveTypeCode,Comments,PromoAllOrNothing,NeedPriceApprovedBy,PromoFromDatetime,PromolToDatetime,TPBackground,SubmitDatetime,SubmittedByUserID,CreatedByUserID,CreatedDateTime,LastModifiedByUserID,LastModifiedDatetime,QuoteExpirationDate,RejRetReason,NonPriceProtectionAccount,SerialNumber,PublicComments,PrivateComments,AccountManagerID,ExpiryNotificationDate,Currency,QuoteSubTypeID,CRM_Status,CRM_Messages,PromoType,FundPlan,Fund,RSMApprovedByUserID,RSMActualApprovedByUserID,RSMApprovedDateTime,RSDApprovedByUserID,RSDActualApprovedByUserID,RSDApprovedDateTime,BidDeskApprovedByUserID,BidDeskActualApprovedByUserID,BidDeskApprovedDateTime,MMApprovedByUserID,MMActualApprovedByUserID,MMApprovedDateTime,PMApprovedByUserID,PMActualApprovedByUserID,PMApprovedDateTime,VPSalesApprovedByUserID,VPSalesActualApprovedByUserID,VPSalesApprovedDateTime,VPFinanceApprovedByUserID,VPFinanceActualApprovedByUserID,VPFinanceApprovedDateTime,IsNotAllIn,IsCostAdder,FulfillmentFileInfoID,FulfillmentSheet,CreatedByActualUserId,SubmittedByActualUserId,CanceledByUserID,CanceledDateTime,CancelReason,SecondExpiryNotificationDate,FinalExpiryNotificationDate,LossNotificationDate,TotalValue,IsFIAll,IsDistributeAcrossAllSKU,RSDApproverUserID,RMMApprovedByUserID,RMMApprovedDateTime,RMMActualApprovedByUserID,MDApprovedByUserID,MDApprovedDateTime,MDActualApprovedByUserID,RFMApprovedByUserID,RFMApprovedDateTime,RFMActualApprovedByUserID,RFCApprovedByUserID,RFCApprovedDateTime,RFCActualApprovedByUserID,ExchangeRate,TemplateID,IgnoreTemplate,ReferenceNumber,PromoID,PayToT2,Application,Project,ExistingProject,ExpectedShipDate,WinLossDateTime,WinLossUserID,RevenueApporvalDate,InQWinlossDate,BillTo,ShipTo,IsDealReg,CommentforPDF,IsQuoteCreateFromCRM,PEApprovedByUserId,PEActualApprovedByUserId,PEApprovedDateTime,Action,CustomerQuarter,CustomerYear,FinalReviewerActualApproverUserID,FinalReviewerApprovalDate,FinalReviewerApproverUserID,PricingTerm,VolumeCommitment,IsQuoteSent,IsApproveFloorFlow")] Quote quote)
        {
            if (id != quote.QuoteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.QuoteID))
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
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quote
                .SingleOrDefaultAsync(m => m.QuoteID == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var quote = await _context.Quote.SingleOrDefaultAsync(m => m.QuoteID == id);
            _context.Quote.Remove(quote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(long id)
        {
            return _context.Quote.Any(e => e.QuoteID == id);
        }


    }
}
