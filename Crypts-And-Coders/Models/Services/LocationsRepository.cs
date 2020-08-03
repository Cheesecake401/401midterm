using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class LocationsRepository : ILocation
    {
        private CryptsDbContext _context;
        
        public LocationsRepository(CryptsDbContext context)
        {
            _context = context;

        }

        public async Task<Location> Create(Location location)
        {
            _context.Entry(location).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task Delete(int id)
        {
            Location location = await _context.Location.FindAsync(id);
            if (location != null)
            {
                _context.Entry(location).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Location>> GetLocations()
        {
            List<Location> result = await _context.Location.ToListAsync();
            return result;
        }

        public async Task<Location> GetLocation(int id)
        {
            var result = await _context.Location.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Location> Update(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return location;
        }
    }
}