using Jamia.Data;
using Jamia.Infrastructure;
using Jamia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jamia.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    [Authorize(Roles = RoleNames.Admin, Policy = PolicyNames.Status)]
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Sessions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Session.Include(s => s.Campus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Sessions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session
                .Include(s => s.Campus)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // GET: Admin/Sessions/Create
        public IActionResult Create()
        {
            ViewData["CampusId"] = new SelectList(_context.Campus, "ID", "Address");
            return View();
        }

        // POST: Admin/Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SessionName,Description,StartDate,EndDate,CampusId")] Session session)
        {
            if (ModelState.IsValid)
            {
                session.ID = Guid.NewGuid();
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampusId"] = new SelectList(_context.Campus, "ID", "Address", session.CampusId);
            return View(session);
        }

        // GET: Admin/Sessions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            ViewData["CampusId"] = new SelectList(_context.Campus, "ID", "Address", session.CampusId);
            return View(session);
        }

        // POST: Admin/Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,SessionName,Description,StartDate,EndDate,CampusId")] Session session)
        {
            if (id != session.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.ID))
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
            ViewData["CampusId"] = new SelectList(_context.Campus, "ID", "Address", session.CampusId);
            return View(session);
        }

        // GET: Admin/Sessions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session
                .Include(s => s.Campus)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Admin/Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var session = await _context.Session.FindAsync(id);
            _context.Session.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(Guid id)
        {
            return _context.Session.Any(e => e.ID == id);
        }
    }
}
