using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Interfaces
{
    public interface ILocation
    {
        /// <summary>
        /// Creates a new location in the database
        /// </summary>
        /// <param name="location">Location information for creation</param>
        /// <returns>Successful result of location creation</returns>
        Task<Location> Create(Location location);

        /// <summary>
        /// Get a list of all locations in the database
        /// </summary>
        /// <returns>Successful result with list of locations</returns>
        Task<List<Location>> GetLocations();

        /// <summary>
        /// Get a specific location in the database by ID
        /// </summary>
        /// <param name="id">Id of location to search for</param>
        /// <returns>Successful result of specified location</returns>
        Task<Location> GetLocation(int id);

        /// <summary>
        /// Update a given location in the database
        /// </summary>
        /// <param name="location">Location information for update</param>
        /// <returns>Successful result of specified updated location</returns>
        Task<Location> Update(Location location);

        /// <summary>
        /// Delete a location from the database
        /// </summary>
        /// <param name="id">Id of location to be deleted</param>
        /// <returns>Task of completion for location delete</returns>
        Task Delete(int id);

        // TODO: add enemy to locations?
    }
}