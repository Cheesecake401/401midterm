using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Interfaces
{
    public interface ILocations
    {
        //Create a location
        Task<Locations> Create(Locations locations);
        //Read a location/Get
        Task<List<Locations>> GetLocations();
        //Get by location id
        Task<Locations> GetLocations(int id);
        //Update a location
        Task Update(Locations locations);
        //Delete a location
        Task Delete(int id);
    }
}
