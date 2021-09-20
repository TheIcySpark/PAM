using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAM.Data;
using PAM.Models;

namespace PAM.Controllers
{
    public class IMDBItemsController : Controller
    {
        private readonly PAMContext _context;
        private readonly ViewBagImageController _viewBagImageController;

        public IMDBItemsController(PAMContext context)
        {
            _context = context;
            _viewBagImageController = new ViewBagImageController(_context);
        }

        // GET: IMDBItems
        public async Task<IActionResult> Index()
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            return View(await _context.IMDBItem.ToListAsync());
        }

        // GET: IMDBItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            if (id == null)
            {
                return NotFound();
            }

            var iMDBItem = await _context.IMDBItem
                .FirstOrDefaultAsync(m => m.IMDBItemID == id);
            if (iMDBItem == null)
            {
                return NotFound();
            }

            return View(iMDBItem);
        }

        // GET: IMDBItems/Create
        public IActionResult Create()
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            return View();
        }

        // POST: IMDBItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IMDBItemID,Awards,ContentRating,IMDBRating,IMDBID,ImageLink,MetacriticRating,Plot,Runtime,Title,TrailerLink,Type,Year")] IMDBItem iMDBItem)
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            if (ModelState.IsValid)
            {
                _context.Add(iMDBItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iMDBItem);
        }

        // GET: IMDBItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            if (id == null)
            {
                return NotFound();
            }

            var iMDBItem = await _context.IMDBItem.FindAsync(id);
            if (iMDBItem == null)
            {
                return NotFound();
            }
            return View(iMDBItem);
        }

        // POST: IMDBItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IMDBItemID,Awards,ContentRating,IMDBRating,IMDBID,ImageLink,MetacriticRating,Plot,Runtime,Title,TrailerLink,Type,Year")] IMDBItem iMDBItem)
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            if (id != iMDBItem.IMDBItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iMDBItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IMDBItemExists(iMDBItem.IMDBItemID))
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
            return View(iMDBItem);
        }

        // GET: IMDBItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            if (id == null)
            {
                return NotFound();
            }

            var iMDBItem = await _context.IMDBItem
                .FirstOrDefaultAsync(m => m.IMDBItemID == id);
            if (iMDBItem == null)
            {
                return NotFound();
            }

            return View(iMDBItem);
        }

        // POST: IMDBItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            var iMDBItem = await _context.IMDBItem.FindAsync(id);
            _context.IMDBItem.Remove(iMDBItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IMDBItemExists(int id)
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            return _context.IMDBItem.Any(e => e.IMDBItemID == id);
        }
    }
}
