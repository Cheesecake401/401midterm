using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class UserServices
    {
        // Utilize this service for authorization
        private CryptsDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public UserServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, CryptsDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Just an example from class, doesnt really do much
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        public static async Task<bool> ValidateUser(ClaimsPrincipal User, ICharacter _character, int id)
        {
            var character = await _character.GetCharacter(id);

            //Only allow players to view their own character's information
            string userName = User.FindFirst("UserName").Value;

            if (User.IsInRole("Player") && userName != character.UserName)
            {
                return false;
            }
            return true;
        }
    }
}
