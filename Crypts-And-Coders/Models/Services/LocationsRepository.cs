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
    private ILocation _location;

        public LocationsRepository(CryptsDbContext context, ILocation location)
        {
            _context = context;
            _location = location;
        }
        public async Task<Location> Create(Location location)
        {
            Location entity = new Location()
            {
                Id = location.Id,
                Name = location.Name,
                Description = location.Description,
            };

            _context.Entry(location).State = EntityState.Added;
            await _context.SaveChangesAsync();

            location.Id = entity.Id;
            return location;
        }

        public async Task Delete(int id)
        {
            Location location = await GetLocations(id);
            _context.Entry(location).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Location>> GetLocations()
        {
            var location = await _context.Location.ToListAsync();
            return location;
        }

        public async Task<Location> GetLocations(int id)
        {
            Location location = await _context.Location.FindAsync(id);
            return location;
        }

        public async Task<Location> Update(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return location;
        }
    }
}
