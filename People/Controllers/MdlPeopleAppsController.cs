using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using People.Data;
using People.Models;

namespace People.Controllers
{
    public class MdlPeopleAppsController : Controller
    {
        private readonly PeopleDbContext _context;

        public MdlPeopleAppsController(PeopleDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: MdlPeopleApps
        public async Task<IActionResult> Index()
        {
              return _context.MdlPeopleApp != null ? 
                          View(await _context.MdlPeopleApp.ToListAsync()) :
                          Problem("Entity set 'PeopleDbContext.MdlPeopleApp'  is null.");
        }

        [Authorize]
        // GET: MdlPeopleApps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MdlPeopleApp == null)
            {
                return NotFound();
            }

            var mdlPeopleApp = await _context.MdlPeopleApp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mdlPeopleApp == null)
            {
                return NotFound();
            }

            return View(mdlPeopleApp);
        }

        [Authorize]
        // GET: MdlPeopleApps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MdlPeopleApps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Genter,Email,Phone,StNumber,StName,StCity,StState,StZip,AddressLine,JobTitle,Race,Dated,Avatar,UserIn,CompanyName,RecCount,UserId")] MdlPeopleApp mdlPeopleApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mdlPeopleApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdlPeopleApp);
        }

        [Authorize]
        // GET: MdlPeopleApps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MdlPeopleApp == null)
            {
                return NotFound();
            }

            var mdlPeopleApp = await _context.MdlPeopleApp.FindAsync(id);
            if (mdlPeopleApp == null)
            {
                return NotFound();
            }
            return View(mdlPeopleApp);
        }

        [Authorize]
        // POST: MdlPeopleApps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Genter,Email,Phone,StNumber,StName,StCity,StState,StZip,AddressLine,JobTitle,Race,Dated,Avatar,UserIn,CompanyName,RecCount,UserId")] MdlPeopleApp mdlPeopleApp)
        {
            if (id != mdlPeopleApp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mdlPeopleApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MdlPeopleAppExists(mdlPeopleApp.Id))
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
            return View(mdlPeopleApp);
        }

        [Authorize]
        // GET: MdlPeopleApps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MdlPeopleApp == null)
            {
                return NotFound();
            }

            var mdlPeopleApp = await _context.MdlPeopleApp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mdlPeopleApp == null)
            {
                return NotFound();
            }

            return View(mdlPeopleApp);
        }

        [Authorize]
        // POST: MdlPeopleApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MdlPeopleApp == null)
            {
                return Problem("Entity set 'PeopleDbContext.MdlPeopleApp'  is null.");
            }
            var mdlPeopleApp = await _context.MdlPeopleApp.FindAsync(id);
            if (mdlPeopleApp != null)
            {
                _context.MdlPeopleApp.Remove(mdlPeopleApp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MdlPeopleAppExists(int id)
        {
          return (_context.MdlPeopleApp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
