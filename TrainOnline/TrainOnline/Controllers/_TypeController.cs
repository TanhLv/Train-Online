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
    public class _TypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public _TypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: _Type
        public async Task<IActionResult> Index()
        {
              return _context.Types != null ? 
                          View(await _context.Types.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Types'  is null.");
        }

        // GET: _Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Types == null)
            {
                return NotFound();
            }

            var _Type = await _context.Types
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (_Type == null)
            {
                return NotFound();
            }

            return View(_Type);
        }

        // GET: _Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: _Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeName,Value,CSSClass,Sorting,StateId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,DeleteDate")] _Type _Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_Type);
        }

        // GET: _Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Types == null)
            {
                return NotFound();
            }

            var _Type = await _context.Types.FindAsync(id);
            if (_Type == null)
            {
                return NotFound();
            }
            return View(_Type);
        }

        // POST: _Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName,Value,CSSClass,Sorting,StateId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,DeleteDate")] _Type _Type)
        {
            if (id != _Type.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_TypeExists(_Type.TypeId))
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
            return View(_Type);
        }

        // GET: _Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Types == null)
            {
                return NotFound();
            }

            var _Type = await _context.Types
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (_Type == null)
            {
                return NotFound();
            }

            return View(_Type);
        }

        // POST: _Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Types == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Types'  is null.");
            }
            var _Type = await _context.Types.FindAsync(id);
            if (_Type != null)
            {
                _context.Types.Remove(_Type);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool _TypeExists(int id)
        {
          return (_context.Types?.Any(e => e.TypeId == id)).GetValueOrDefault();
        }
    }
}
