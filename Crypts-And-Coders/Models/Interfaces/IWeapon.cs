using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Interfaces
{
    public interface IWeapon
    {
        /// <summary>
        /// create property
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        Task<Weapon> Create(Weapon weapon);

        /// <summary>
        /// read property
        /// </summary>
        /// <returns></returns>
        Task<List<Weapon>> GetWeapons();

        /// <summary>
        /// read specific property
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Weapon> GetWeapon(int id);

        /// <summary>
        /// update property
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        Task<Weapon> Update(Weapon weapon);

        /// <summary>
        /// delete property
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);


    }
}
