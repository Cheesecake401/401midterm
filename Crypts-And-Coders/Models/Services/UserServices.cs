using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.DTOs;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class UserServices
    {
        /// <summary>
        /// Just an example from class, doesnt really do much
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        public static bool ValidateUser(ClaimsPrincipal User, ICharacter _character, int id)
        {
            string userNameInDB = _character.GetCharacterSync(id);
            //Only allow players to view their own character's information
            string userName = User.FindFirst("UserName").Value;

            if (User.IsInRole("Player") && userName != userNameInDB)
            {
                return false;
            }
            return true;
        }
    }
}
