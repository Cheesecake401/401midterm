using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class WeaponRepository : IWeapon
    {
        private CryptsDbContext _context;

        public WeaponRepository(CryptsDbContext context)
        {
            _context = context;
        }

        public async Task<Weapon> Create(Weapon weapon)
        {
            _context.Entry(weapon).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return weapon;
        }

        public async Task Delete(int id)
        {
            Weapon weapon = await _context.Weapon.FindAsync(id);
            if (weapon != null)
            {
                _context.Entry(weapon).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Weapon> GetWeapon(int id)
        {
            var result = await _context.Weapon.Where(x => x.Id == id)
                                                 .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<Weapon>> GetWeapons()
        {
            List<Weapon> result = await _context.Weapon.ToListAsync();
            return result;
        }

        public async Task<Weapon> Update(Weapon weapon)
        {
            _context.Entry(weapon).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return weapon;
        }
    }
}
