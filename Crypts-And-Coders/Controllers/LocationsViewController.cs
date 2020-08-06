using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Crypts_And_Coders.Models.DTOs;
using Crypts_And_Coders.Models.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Crypts_And_Coders.Controllers
{
    [AllowAnonymous]
    public class LocationsViewController : Controller
    {
        private readonly ILocation _location;
        private readonly CryptsDbContext _context;

        public LocationsViewController(CryptsDbContext context, ILocation location)
        {
            _location = location;
            _context = context;
        }

        // GET: LocationsView
        public async Task<IActionResult> Index()
        {
            var allLocations = await _location.GetLocations();
            return View(allLocations);
        }

        // GET: LocationsView/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: LocationsView/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationsView/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Location>> Create([Bind("Id,Name,Description")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: LocationsView/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: LocationsView/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Location location)
        {
            if (id != location.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.Id))
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
            return View(location);
        }

        // GET: LocationsView/Delete/5
        //[BindProperty]
        //public LocationDTO Location { get; set; }

        //public async Task<IActionResult> Delete(int id)
        //{
        //    Location = await _location.GetLocation(id);
        //    if (Location == null)
        //    {
        //        return NotFound();
        //    }

        //    //var location = await _context.Location
        //    //    .FirstOrDefaultAsync(m => m.Id == id);
        //    return View(Location);
        //}
        [BindProperty]
        public LocationDTO Location { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Location = await _location.GetLocation(id);

            if (Location == null)
            {
                return RedirectToPage("/NotFound");
            }
            return View(Location);
        }

        public async Task<IActionResult> OnPost()
        {
            await _location.Delete(Location.Id);
            return RedirectToPage("Index");
        }

        // POST: LocationsView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Location.FindAsync(id);
            _context.Location.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.Id == id);
        }
    }
}