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
        private readonly IEnemy _enemy;

        public LocationsRepository(CryptsDbContext context, IEnemy enemy)
        {
            _context = context;
            _enemy = enemy;
        }

        /// <summary>
        /// Creates a new location in the database
        /// </summary>
        /// <param name="location">Location information for creation</param>
        /// <returns>Successful result of location creation</returns>
        public async Task<Location> Create(Location location)
        {
            _context.Entry(location).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return location;
        }

        /// <summary>
        /// Delete a location from the database
        /// </summary>
        /// <param name="id">Id of location to be deleted</param>
        /// <returns>Task of completion for location delete</returns>
        public async Task Delete(int id)
        {
            Location location = await _context.Location.FindAsync(id);
            if (location != null)
            {
                _context.Entry(location).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a list of all locations in the database
        /// </summary>
        /// <returns>Successful result with list of locations</returns>
        public async Task<List<Location>> GetLocations()
        {
            List<Location> result = await _context.Location.Include(x => x.EnemiesInLocation).ToListAsync();

            return result;
        }

        /// <summary>
        /// Get a specific location in the database by ID
        /// </summary>
        /// <param name="id">Id of location to search for</param>
        /// <returns>Successful result of specified location</returns>
        public async Task<Location> GetLocation(int id)
        {
            var result = await _context.Location.Where(x => x.Id == id).Include(x  => x.EnemiesInLocation).FirstOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Update a given location in the database
        /// </summary>
        /// <param name="id">Id of location to be updated</param>
        /// <param name="location">Location information for update</param>
        /// <returns>Successful result of specified updated location</returns>
        public async Task<Location> Update(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return location;
        }
    }
}