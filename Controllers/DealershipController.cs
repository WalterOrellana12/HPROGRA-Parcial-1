using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using walterParcial1.Models;

namespace walterParcial1.Controllers
{
    public class DealershipController : Controller
    {
        private readonly CarContext _context;

        public DealershipController(CarContext context)
        {
            _context = context;
        }

        // GET: Dealership
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarDealership.ToListAsync());
        }

        // GET: Dealership/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDealership = await _context.CarDealership
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carDealership == null)
            {
                return NotFound();
            }

            return View(carDealership);
        }

        // GET: Dealership/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dealership/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,City,ZipCode")] CarDealership carDealership)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(carDealership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carDealership);
        }

        // GET: Dealership/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDealership = await _context.CarDealership.FindAsync(id);
            if (carDealership == null)
            {
                return NotFound();
            }
            return View(carDealership);
        }

        // POST: Dealership/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,ZipCode")] CarDealership carDealership)
        {
            if (id != carDealership.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carDealership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarDealershipExists(carDealership.Id))
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
            return View(carDealership);
        }

        // GET: Dealership/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDealership = await _context.CarDealership
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carDealership == null)
            {
                return NotFound();
            }

            return View(carDealership);
        }

        // POST: Dealership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDealership = await _context.CarDealership.FindAsync(id);
            if (carDealership != null)
            {
                _context.CarDealership.Remove(carDealership);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarDealershipExists(int id)
        {
            return _context.CarDealership.Any(e => e.Id == id);
        }
    }
}
