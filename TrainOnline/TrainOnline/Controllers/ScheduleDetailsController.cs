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
    public class ScheduleDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScheduleDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ScheduleDetails.Include(s => s.GetCurrentStation).Include(s => s.GetNextStation).Include(s => s.GetScheduleId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ScheduleDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ScheduleDetails == null)
            {
                return NotFound();
            }

            var scheduleDetail = await _context.ScheduleDetails
                .Include(s => s.GetCurrentStation)
                .Include(s => s.GetNextStation)
                .Include(s => s.GetScheduleId)
                .FirstOrDefaultAsync(m => m.ScheduleDetailId == id);
            if (scheduleDetail == null)
            {
                return NotFound();
            }

            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Create
        public IActionResult Create()
        {
            ViewData["CurrentStation"] = new SelectList(_context.Stations, "StationId", "StationId");
            ViewData["NextStation"] = new SelectList(_context.Stations, "StationId", "StationId");
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId");
            return View();
        }

        // POST: ScheduleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleDetailId,ScheduleId,CurrentStation,NextStation,PriceToTheNextStation,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,DeleteDate")] ScheduleDetail scheduleDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrentStation"] = new SelectList(_context.Stations, "StationId", "StationId", scheduleDetail.CurrentStation);
            ViewData["NextStation"] = new SelectList(_context.Stations, "StationId", "StationId", scheduleDetail.NextStation);
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", scheduleDetail.ScheduleId);
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ScheduleDetails == null)
            {
                return NotFound();
            }

            var scheduleDetail = await _context.ScheduleDetails.FindAsync(id);
            if (scheduleDetail == null)
            {
                return NotFound();
            }
            ViewData["CurrentStation"] = new SelectList(_context.Stations, "StationId", "StationId", scheduleDetail.CurrentStation);
            ViewData["NextStation"] = new SelectList(_context.Stations, "StationId", "StationId", scheduleDetail.NextStation);
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", scheduleDetail.ScheduleId);
            return View(scheduleDetail);
        }

        // POST: ScheduleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleDetailId,ScheduleId,CurrentStation,NextStation,PriceToTheNextStation,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,DeleteDate")] ScheduleDetail scheduleDetail)
        {
            if (id != scheduleDetail.ScheduleDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleDetailExists(scheduleDetail.ScheduleDetailId))
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
            ViewData["CurrentStation"] = new SelectList(_context.Stations, "StationId", "StationId", scheduleDetail.CurrentStation);
            ViewData["NextStation"] = new SelectList(_context.Stations, "StationId", "StationId", scheduleDetail.NextStation);
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", scheduleDetail.ScheduleId);
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ScheduleDetails == null)
            {
                return NotFound();
            }

            var scheduleDetail = await _context.ScheduleDetails
                .Include(s => s.GetCurrentStation)
                .Include(s => s.GetNextStation)
                .Include(s => s.GetScheduleId)
                .FirstOrDefaultAsync(m => m.ScheduleDetailId == id);
            if (scheduleDetail == null)
            {
                return NotFound();
            }

            return View(scheduleDetail);
        }

        // POST: ScheduleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ScheduleDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ScheduleDetails'  is null.");
            }
            var scheduleDetail = await _context.ScheduleDetails.FindAsync(id);
            if (scheduleDetail != null)
            {
                _context.ScheduleDetails.Remove(scheduleDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleDetailExists(int id)
        {
          return (_context.ScheduleDetails?.Any(e => e.ScheduleDetailId == id)).GetValueOrDefault();
        }
    }
}
