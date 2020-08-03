using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Interfaces
{
    public interface ILocation
    {
        //Create a location
        Task<Location> Create(Location location);
        //Read a location/Get
        Task<List<Location>> GetLocations();
        //Get by location id
        Task<Location> GetLocations(int id);
        //Update a location
        Task<Location> Update(Location location);
        //Delete a location
        Task Delete(int id);
    }
}
