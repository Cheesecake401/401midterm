using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models
{
    public class ApplicationUser : IdentityUser
    {
    }

    public static class ApplicationRoles
    {
        public const string GameMaster = "Game Master";
        public const string Player = "Player";
    }
}