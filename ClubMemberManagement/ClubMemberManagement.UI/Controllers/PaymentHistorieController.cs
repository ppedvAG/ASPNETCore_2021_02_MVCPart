using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubMemberManagement.UI.Data;
using ClubMemberManagement.UI.Models;
using ClubMemberManagement.UI.ViewModels;

namespace ClubMemberManagement.UI.Controllers
{
    public class PaymentHistorieController : Controller
    {
        private readonly ClubMemberManagementDbContext _context;

        public PaymentHistorieController(ClubMemberManagementDbContext context)
        {
            _context = context;
        }

        // GET: PaymentHistorie
        public async Task<IActionResult> Index()
        {
            var clubMemberManagementDbContext = _context.PaymentHistory.Include(p => p.MemberPayments);
            return View(await clubMemberManagementDbContext.ToListAsync());
        }

        // GET: PaymentHistorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHistory = await _context.PaymentHistory
                .Include(p => p.MemberPayments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentHistory == null)
            {
                return NotFound();
            }

            return View(paymentHistory);
        }


        // GET: PaymentHistorie/Create
        public IActionResult Create(int id)
        {
            TempData["PaymentMemberId"] = id;
            
            PaymentHistory paymentHistory = new PaymentHistory();
            paymentHistory.MemberPaymentId = id;
            return View(paymentHistory);
        }

        // POST: PaymentHistorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Payed,PayedDate, MemberPaymentId ")] PaymentHistory create)
        {
            if (ModelState.IsValid)
            {
                create.MemberPaymentId = Convert.ToInt32(TempData["PaymentMemberId"]);
                _context.Add(create);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["MemberPaymentId"] = new SelectList(_context.MembershipPayment, "Id", "Id", paymentHistory.MemberPaymentId);
            return View(create);
        }

        // GET: PaymentHistorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHistory = await _context.PaymentHistory.FindAsync(id);
            if (paymentHistory == null)
            {
                return NotFound();
            }
            ViewData["MemberPaymentId"] = new SelectList(_context.MembershipPayment, "Id", "Id", paymentHistory.MemberPaymentId);
            return View(paymentHistory);
        }

        // POST: PaymentHistorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Payed,PayedDate,MemberPaymentId")] PaymentHistory paymentHistory)
        {
            if (id != paymentHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentHistoryExists(paymentHistory.Id))
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
            ViewData["MemberPaymentId"] = new SelectList(_context.MembershipPayment, "Id", "Id", paymentHistory.MemberPaymentId);
            return View(paymentHistory);
        }

        // GET: PaymentHistorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHistory = await _context.PaymentHistory
                .Include(p => p.MemberPayments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentHistory == null)
            {
                return NotFound();
            }

            return View(paymentHistory);
        }

        // POST: PaymentHistorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentHistory = await _context.PaymentHistory.FindAsync(id);
            _context.PaymentHistory.Remove(paymentHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentHistoryExists(int id)
        {
            return _context.PaymentHistory.Any(e => e.Id == id);
        }
    }
}
