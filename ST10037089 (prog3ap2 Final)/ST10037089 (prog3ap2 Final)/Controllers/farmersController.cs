using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST10037089__prog3ap2_Final_.Data;
using ST10037089__prog3ap2_Final_.Models;

namespace ST10037089__prog3ap2_Final_.Controllers
{
    [Authorize(Roles = "Employee")]
    public class farmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public farmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: farmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.farmers.ToListAsync());
        }

        // GET: farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmers = await _context.farmers
                .FirstOrDefaultAsync(m => m.farmerid == id);
            if (farmers == null)
            {
                return NotFound();
            }

            return View(farmers);
        }

        // GET: farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: farmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("farmerid,farmername,farmersurname,farmeremail,password,farmerType,farmerLocation")] farmers farmers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmers);
        }

        // GET: farmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmers = await _context.farmers.FindAsync(id);
            if (farmers == null)
            {
                return NotFound();
            }
            return View(farmers);
        }

        // POST: farmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("farmerid,farmername,farmersurname,farmeremail,password,farmerType,farmerLocation")] farmers farmers)
        {
            if (id != farmers.farmerid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!farmersExists(farmers.farmerid))
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
            return View(farmers);
        }

        // GET: farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmers = await _context.farmers
                .FirstOrDefaultAsync(m => m.farmerid == id);
            if (farmers == null)
            {
                return NotFound();
            }

            return View(farmers);
        }

        // POST: farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmers = await _context.farmers.FindAsync(id);
            if (farmers != null)
            {
                _context.farmers.Remove(farmers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool farmersExists(int id)
        {
            return _context.farmers.Any(e => e.farmerid == id);
        }
    }
}
