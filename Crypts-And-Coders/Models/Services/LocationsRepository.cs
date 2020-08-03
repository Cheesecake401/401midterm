using Crypts_And_Coders.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class LocationsRepository : ILocation
    {
        public Task<Location> Create(Location location)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Location>> GetLocations()
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetLocations(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
