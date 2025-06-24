using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendingMachineMVC.Data;
using VendingMachineMVC.Models.Entities;

namespace VendingMachineMVC.Controllers
{
    public class SpiralsController : Controller
    {
        private readonly VendingDbContext _context;

        public SpiralsController(VendingDbContext context)
        {
            _context = context;
        }

        // GET: Spirals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spirals.ToListAsync());
        }

        // GET: Spirals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spiral = await _context.Spirals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spiral == null)
            {
                return NotFound();
            }

            return View(spiral);
        }

        // GET: Spirals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spirals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Position,Id,Positions,IsDisabled")] Spiral spiral)
        {
            if (ModelState.IsValid)
            {
                spiral.Id = Guid.NewGuid();
                _context.Add(spiral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spiral);
        }

        // GET: Spirals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spiral = await _context.Spirals.FindAsync(id);
            if (spiral == null)
            {
                return NotFound();
            }
            return View(spiral);
        }

        // POST: Spirals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Position,Id,Positions,IsDisabled")] Spiral spiral)
        {
            if (id != spiral.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spiral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpiralExists(spiral.Id))
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
            return View(spiral);
        }

        // GET: Spirals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spiral = await _context.Spirals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spiral == null)
            {
                return NotFound();
            }

            return View(spiral);
        }

        // POST: Spirals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var spiral = await _context.Spirals.FindAsync(id);
            if (spiral != null)
            {
                _context.Spirals.Remove(spiral);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpiralExists(Guid id)
        {
            return _context.Spirals.Any(e => e.Id == id);
        }
    }
}
