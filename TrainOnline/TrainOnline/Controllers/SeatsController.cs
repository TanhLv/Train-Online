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
    public class SeatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Seats.Include(s => s.GetStatusId).Include(s => s.GetTrainCarId).Include(s => s.GetTypeId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Seats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seats == null)
            {
                return NotFound();
            }

            var seat = await _context.Seats
                .Include(s => s.GetStatusId)
                .Include(s => s.GetTrainCarId)
                .Include(s => s.GetTypeId)
                .FirstOrDefaultAsync(m => m.SeatId == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // GET: Seats/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId");
            ViewData["TrainCarId"] = new SelectList(_context.TrainCars, "TrainCarId", "TrainCarId");
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId");
            return View();
        }

        // POST: Seats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeatId,SeatCode,TrainCarId,TypeId,StatusId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,DeleteDate")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", seat.StatusId);
            ViewData["TrainCarId"] = new SelectList(_context.TrainCars, "TrainCarId", "TrainCarId", seat.TrainCarId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId", seat.TypeId);
            return View(seat);
        }

        // GET: Seats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seats == null)
            {
                return NotFound();
            }

            var seat = await _context.Seats.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", seat.StatusId);
            ViewData["TrainCarId"] = new SelectList(_context.TrainCars, "TrainCarId", "TrainCarId", seat.TrainCarId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId", seat.TypeId);
            return View(seat);
        }

        // POST: Seats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeatId,SeatCode,TrainCarId,TypeId,StatusId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,DeleteDate")] Seat seat)
        {
            if (id != seat.SeatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatExists(seat.SeatId))
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
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", seat.StatusId);
            ViewData["TrainCarId"] = new SelectList(_context.TrainCars, "TrainCarId", "TrainCarId", seat.TrainCarId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeId", seat.TypeId);
            return View(seat);
        }

        // GET: Seats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seats == null)
            {
                return NotFound();
            }

            var seat = await _context.Seats
                .Include(s => s.GetStatusId)
                .Include(s => s.GetTrainCarId)
                .Include(s => s.GetTypeId)
                .FirstOrDefaultAsync(m => m.SeatId == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // POST: Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seats == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Seats'  is null.");
            }
            var seat = await _context.Seats.FindAsync(id);
            if (seat != null)
            {
                _context.Seats.Remove(seat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatExists(int id)
        {
          return (_context.Seats?.Any(e => e.SeatId == id)).GetValueOrDefault();
        }
    }
}
