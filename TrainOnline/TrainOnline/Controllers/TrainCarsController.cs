using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainOnline.Data;
using TrainOnline.Models;

namespace TrainOnline.Controllers
{
    public class TrainCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrainCars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TrainCars.Include(t => t.GetStatusId).Include(t => t.GetTrainId).Include(t => t.GetTypeId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TrainCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrainCars == null)
            {
                return NotFound();
            }

            var trainCar = await _context.TrainCars
                .Include(t => t.GetStatusId)
                .Include(t => t.GetTrainId)
                .Include(t => t.GetTypeId)
                .FirstOrDefaultAsync(m => m.TrainCarId == id);
            if (trainCar == null)
            {
                return NotFound();
            }

            return View(trainCar);
        }

        // GET: TrainCars/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId");
            ViewData["TrainId"] = new SelectList(_context.Trains, "TrainId", "TrainId");
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId");
            return View();
        }

        // POST: TrainCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainCarId,TrainCarNumber,TrainId,TypeId,StatusId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,DeleteDate")] TrainCar trainCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", trainCar.StatusId);
            ViewData["TrainId"] = new SelectList(_context.Trains, "TrainId", "TrainId", trainCar.TrainId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId", trainCar.TypeId);
            return View(trainCar);
        }

        // GET: TrainCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrainCars == null)
            {
                return NotFound();
            }

            var trainCar = await _context.TrainCars.FindAsync(id);
            if (trainCar == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", trainCar.StatusId);
            ViewData["TrainId"] = new SelectList(_context.Trains, "TrainId", "TrainId", trainCar.TrainId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId", trainCar.TypeId);
            return View(trainCar);
        }

        // POST: TrainCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainCarId,TrainCarNumber,TrainId,TypeId,StatusId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,DeleteDate")] TrainCar trainCar)
        {
            if (id != trainCar.TrainCarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainCarExists(trainCar.TrainCarId))
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
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", trainCar.StatusId);
            ViewData["TrainId"] = new SelectList(_context.Trains, "TrainId", "TrainId", trainCar.TrainId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId", trainCar.TypeId);
            return View(trainCar);
        }

        // GET: TrainCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrainCars == null)
            {
                return NotFound();
            }

            var trainCar = await _context.TrainCars
                .Include(t => t.GetStatusId)
                .Include(t => t.GetTrainId)
                .Include(t => t.GetTypeId)
                .FirstOrDefaultAsync(m => m.TrainCarId == id);
            if (trainCar == null)
            {
                return NotFound();
            }

            return View(trainCar);
        }

        // POST: TrainCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrainCars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TrainCars'  is null.");
            }
            var trainCar = await _context.TrainCars.FindAsync(id);
            if (trainCar != null)
            {
                _context.TrainCars.Remove(trainCar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainCarExists(int id)
        {
          return (_context.TrainCars?.Any(e => e.TrainCarId == id)).GetValueOrDefault();
        }
    }
}
