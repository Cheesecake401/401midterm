using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models;
using Microsoft.AspNetCore.Authorization;
using Crypts_And_Coders.Models.Interfaces;
using Crypts_And_Coders.Models.DTOs;

namespace Crypts_And_Coders.Controllers
{
    [AllowAnonymous]
    public class ItemsViewController : Controller
    {
        private readonly IItem _item;
        private readonly CryptsDbContext _context;

        public ItemsViewController(CryptsDbContext context, IItem item)
        {
            _item = item;
            _context = context;
        }

        // GET: ItemsView
        public async Task<IActionResult> Index()
        {
            var allItems = await _item.GetItems();
            return View(allItems);
        }

        // GET: ItemsView/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _item.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: ItemsView/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemsView/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Item>> Create([Bind("Id,Name,Description")] ItemDTO item)
        {
            if (ModelState.IsValid)
            {
                await _item.Create(item);
                return CreatedAtAction("GetItem", new { id = item.Id }, item);
            }
            return View(item);
        }

        // GET: ItemsView/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _item.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: ItemsView/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            return View(item);
        }

        // GET: ItemsView/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: ItemsView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
    }
}