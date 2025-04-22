using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CookSite.Models;

namespace CookSite.Controllers
{
    public class ManagementCookTypesController : Controller
    {
        private readonly CookSiteContext _context;

        public ManagementCookTypesController()
        {
            _context = new CookSiteContext();
        }

        // GET: ManagementCookTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CookTypes.ToListAsync());
        }

        // GET: ManagementCookTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookType = await _context.CookTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookType == null)
            {
                return NotFound();
            }

            return View(cookType);
        }

        // GET: ManagementCookTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagementCookTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CookType cookType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cookType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cookType);
        }

        // GET: ManagementCookTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookType = await _context.CookTypes.FindAsync(id);
            if (cookType == null)
            {
                return NotFound();
            }
            return View(cookType);
        }

        // POST: ManagementCookTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CookType cookType)
        {
            if (id != cookType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cookType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookTypeExists(cookType.Id))
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
            return View(cookType);
        }

        // GET: ManagementCookTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookType = await _context.CookTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookType == null)
            {
                return NotFound();
            }

            return View(cookType);
        }

        // POST: ManagementCookTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cookType = await _context.CookTypes.FindAsync(id);
            if (cookType != null)
            {
                _context.CookTypes.Remove(cookType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CookTypeExists(int id)
        {
            return _context.CookTypes.Any(e => e.Id == id);
        }
    }
}
