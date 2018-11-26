using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jamia.Data;
using Jamia.Models;

namespace Jamia.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class CampusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/Campus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Campus.Include(c => c.Institute);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SuperAdmin/Campus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campus = await _context.Campus
                .Include(c => c.Institute)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (campus == null)
            {
                return NotFound();
            }

            return View(campus);
        }

        // GET: SuperAdmin/Campus/Create
        public IActionResult Create()
        {
            ViewData["InstituteID"] = new SelectList(_context.Institute, "ID", "Name");
            return View();
        }

        // POST: SuperAdmin/Campus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,InstituteID")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                campus.ID = Guid.NewGuid();
                _context.Add(campus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstituteID"] = new SelectList(_context.Institute, "ID", "Name", campus.InstituteID);
            return View(campus);
        }

        // GET: SuperAdmin/Campus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campus = await _context.Campus.FindAsync(id);
            if (campus == null)
            {
                return NotFound();
            }
            ViewData["InstituteID"] = new SelectList(_context.Institute, "ID", "Name", campus.InstituteID);
            return View(campus);
        }

        // POST: SuperAdmin/Campus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Description,InstituteID")] Campus campus)
        {
            if (id != campus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampusExists(campus.ID))
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
            ViewData["InstituteID"] = new SelectList(_context.Institute, "ID", "Name", campus.InstituteID);
            return View(campus);
        }

        // GET: SuperAdmin/Campus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campus = await _context.Campus
                .Include(c => c.Institute)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (campus == null)
            {
                return NotFound();
            }

            return View(campus);
        }

        // POST: SuperAdmin/Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var campus = await _context.Campus.FindAsync(id);
            _context.Campus.Remove(campus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampusExists(Guid id)
        {
            return _context.Campus.Any(e => e.ID == id);
        }
    }
}
