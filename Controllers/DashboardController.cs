using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PublisherSubscriber.Models;

namespace PublisherSubscriber.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SU_DBContext _context;

        public DashboardController(SU_DBContext context)
        {
            _context = context;
        }

        // GET: Dashboard
        public async Task<IActionResult> Index()
        {
              return _context.ContentTbls != null ? 
                          View(await _context.ContentTbls.ToListAsync()) :
                          Problem("Entity set 'SU_DBContext.ContentTbls'  is null.");
        }

        // GET: Dashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContentTbls == null)
            {
                return NotFound();
            }

            var contentTbl = await _context.ContentTbls
                .FirstOrDefaultAsync(m => m.ContentId == id);
            if (contentTbl == null)
            {
                return NotFound();
            }

            return View(contentTbl);
        }

        // GET: Dashboard/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult YourRequestHasBeenProcessed()
        {
            return View();
        }

        // POST: Dashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContentId,ContentType,ContentName,PersonName,PersonGender,PersonCity,PersonQualification,Subscribe,UnSubscribe")] ContentTbl contentTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentTbl);
                await _context.SaveChangesAsync();
                //return RedirectToAction("");
                return RedirectToAction(nameof(YourRequestHasBeenProcessed));
            }
            return View(contentTbl);
        }

        // GET: Dashboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContentTbls == null)
            {
                return NotFound();
            }

            var contentTbl = await _context.ContentTbls.FindAsync(id);
            if (contentTbl == null)
            {
                return NotFound();
            }
            return View(contentTbl);
        }

        // POST: Dashboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContentId,ContentType,ContentName,PersonName,PersonGender,PersonCity,PersonQualification,Subscribe,UnSubscribe")] ContentTbl contentTbl)
        {
            if (id != contentTbl.ContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentTblExists(contentTbl.ContentId))
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
            return View(contentTbl);
        }

        // GET: Dashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContentTbls == null)
            {
                return NotFound();
            }

            var contentTbl = await _context.ContentTbls
                .FirstOrDefaultAsync(m => m.ContentId == id);
            if (contentTbl == null)
            {
                return NotFound();
            }

            return View(contentTbl);
        }

        // POST: Dashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContentTbls == null)
            {
                return Problem("Entity set 'SU_DBContext.ContentTbls'  is null.");
            }
            var contentTbl = await _context.ContentTbls.FindAsync(id);
            if (contentTbl != null)
            {
                _context.ContentTbls.Remove(contentTbl);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentTblExists(int id)
        {
          return (_context.ContentTbls?.Any(e => e.ContentId == id)).GetValueOrDefault();
        }


    }
}
