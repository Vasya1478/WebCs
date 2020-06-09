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
    public class DoctorsController : Controller
    {
        private readonly stomatologyContext _context;

        public DoctorsController(stomatologyContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            var stomatologyContext = _context.Doctors.Include(d => d.Position).Include(d => d.TimeOfReceipt).Include(d => d.TypeOfService);
            return View(await stomatologyContext.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .Include(d => d.Position)
                .Include(d => d.TimeOfReceipt)
                .Include(d => d.TypeOfService)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.NameOfPosition, "Id", "Id");
            ViewData["TimeOfReceiptId"] = new SelectList(_context.Schedule, "Id", "Id");
            ViewData["TypeOfServiceId"] = new SelectList(_context.NameOfService, "Id", "Id");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeCode,Name,PositionId,CabinetNumber,TimeOfReceiptId,TypeOfServiceId")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionId"] = new SelectList(_context.NameOfPosition, "Id", "Id", doctors.PositionId);
            ViewData["TimeOfReceiptId"] = new SelectList(_context.Schedule, "Id", "Id", doctors.TimeOfReceiptId);
            ViewData["TypeOfServiceId"] = new SelectList(_context.NameOfService, "Id", "Id", doctors.TypeOfServiceId);
            return View(doctors);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.NameOfPosition, "Id", "Id", doctors.PositionId);
            ViewData["TimeOfReceiptId"] = new SelectList(_context.Schedule, "Id", "Id", doctors.TimeOfReceiptId);
            ViewData["TypeOfServiceId"] = new SelectList(_context.NameOfService, "Id", "Id", doctors.TypeOfServiceId);
            return View(doctors);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeCode,Name,PositionId,CabinetNumber,TimeOfReceiptId,TypeOfServiceId")] Doctors doctors)
        {
            if (id != doctors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorsExists(doctors.Id))
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
            ViewData["PositionId"] = new SelectList(_context.NameOfPosition, "Id", "Id", doctors.PositionId);
            ViewData["TimeOfReceiptId"] = new SelectList(_context.Schedule, "Id", "Id", doctors.TimeOfReceiptId);
            ViewData["TypeOfServiceId"] = new SelectList(_context.NameOfService, "Id", "Id", doctors.TypeOfServiceId);
            return View(doctors);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .Include(d => d.Position)
                .Include(d => d.TimeOfReceipt)
                .Include(d => d.TypeOfService)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctors = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorsExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
