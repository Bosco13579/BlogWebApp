using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApp.Data
{
    public class roleMethods
    {
        public RoleManager<IdentityRole> _roleManager;

        public roleMethods(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public Task<IdentityResult> AddRole(IdentityRole role)
        {
            return _roleManager.CreateAsync(role);
        }

    }
}
