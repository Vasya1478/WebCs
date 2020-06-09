using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalJournal2.Models;

namespace MedicalJournal2.Controllers
{
    public class JournalsController : Controller
    {
        private readonly stomatologyContext _context;

        public JournalsController(stomatologyContext context)
        {
            _context = context;
        }

        // GET: Journals
        public async Task<IActionResult> Index()
        {
            var stomatologyContext = _context.Journal.Include(j => j.CardNumber).Include(j => j.DoctorName).Include(j => j.Service);
            return View(await stomatologyContext.ToListAsync());
        }

        // GET: Journals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal
                .Include(j => j.CardNumber)
                .Include(j => j.DoctorName)
                .Include(j => j.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journal == null)
            {
                return NotFound();
            }

            return View(journal);
        }

        // GET: Journals/Create
        public IActionResult Create()
        {
            ViewData["CardNumberId"] = new SelectList(_context.Patients, "Id", "Id");
            ViewData["DoctorNameId"] = new SelectList(_context.Doctors, "Id", "Id");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id");
            return View();
        }

        // POST: Journals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateOfReceipt,CardNumberId,PatientName,DoctorNameId," +
            "DoctorPost,ServiceId,Quantity")] Journal journal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(journal);
              
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CardNumberId"] = new SelectList(_context.Patients, "Id", "Id", journal.CardNumberId);
            ViewData["DoctorNameId"] = new SelectList(_context.Doctors, "Id", "Id", journal.DoctorNameId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id", journal.ServiceId);
            

            return View(journal);
        }

        // GET: Journals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal.FindAsync(id);
            if (journal == null)
            {
                return NotFound();
            }
            ViewData["CardNumberId"] = new SelectList(_context.Patients, "Id", "Id", journal.CardNumberId);
            ViewData["DoctorNameId"] = new SelectList(_context.Doctors, "Id", "Id", journal.DoctorNameId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id", journal.ServiceId);
            return View(journal);
        }

        // POST: Journals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfReceipt,CardNumberId,PatientName,DoctorNameId,DoctorPost,ServiceId,Quantity")] Journal journal)
        {
            if (id != journal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalExists(journal.Id))
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
            ViewData["CardNumberId"] = new SelectList(_context.Patients, "Id", "Id", journal.CardNumberId);
            ViewData["DoctorNameId"] = new SelectList(_context.Doctors, "Id", "Id", journal.DoctorNameId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id", journal.ServiceId);
            return View(journal);
        }

        // GET: Journals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal
                .Include(j => j.CardNumber)
                .Include(j => j.DoctorName)
                .Include(j => j.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journal == null)
            {
                return NotFound();
            }

            return View(journal);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var journal = await _context.Journal.FindAsync(id);
            _context.Journal.Remove(journal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JournalExists(int id)
        {
            return _context.Journal.Any(e => e.Id == id);
        }
    }
}
