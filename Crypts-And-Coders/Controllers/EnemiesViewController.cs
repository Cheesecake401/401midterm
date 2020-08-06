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

namespace Crypts_And_Coders.Controllers
{
    [AllowAnonymous]
    public class EnemiesViewController : Controller
    {
        private readonly IEnemy _enemy;
        private readonly CryptsDbContext _context;

        public EnemiesViewController(CryptsDbContext context, IEnemy enemy)
        {
            _enemy = enemy;
            _context = context;
        }

        // GET: EnemiesView
        public async Task<IActionResult> Index()
        {
            var allEnemies = await _enemy.GetEnemies();
            return View(allEnemies);
        }

        // GET: EnemiesView/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnemiesView/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Abilities,Type,Species")] Enemy enemy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enemy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enemy);
        }

        // GET: EnemiesView/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemy.FindAsync(id);
            if (enemy == null)
            {
                return NotFound();
            }
            return View(enemy);
        }

        // POST: EnemiesView/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Edit(int id, [Bind("Id,Abilities,Type,Species")] Enemy enemy)
        {
            if (id != enemy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enemy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnemyExists(enemy.Id))
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
            return View(enemy);
        }

        // GET: EnemiesView/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enemy == null)
            {
                return NotFound();
            }

            return View(enemy);
        }

        // POST: EnemiesView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enemy = await _context.Enemy.FindAsync(id);
            _context.Enemy.Remove(enemy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnemyExists(int id)
        {
            return _context.Enemy.Any(e => e.Id == id);
        }
    }
}