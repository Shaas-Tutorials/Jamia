using Jamia.Data;
using Jamia.Infrastructure;
using Jamia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jamia.Areas.SuperAdmin.Controllers
{
    [Area(AreaNames.SuperAdmin)]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewData["Institutes"] = new SelectList(_context.Institute.Where(ins => _context.UserInstitute.Any(userIns => userIns.InstituteId == ins.ID && userIns.ApplicationUserId == user.Id)).ToList(), "ID", "Name");
            return View(null);
        }
        [HttpPost]
        public IActionResult GetUsers(string selected_value)
        {
            //var result = _context.Institute.Where(x => x.Name.Contains(term)).Select(x => x.Name).ToList();
            return Json(null);
        }
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(string Id)
        {
            var user = _context.Users.Find(Id);
            return View(user);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string Id, [Bind("Status")] ApplicationUser applicationUser)
        {
            try
            {
                var user = _context.Users.Find(Id);
                user.Status = applicationUser.Status;
                _context.Users.Update(user);
                var claim = new Claim(PolicyNames.Status, Status.Approved.ToString());
                if (applicationUser.Status == Status.Approved)
                    await _userManager.AddClaimAsync(user, claim);
                else
                    await _userManager.RemoveClaimAsync(user, claim);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}