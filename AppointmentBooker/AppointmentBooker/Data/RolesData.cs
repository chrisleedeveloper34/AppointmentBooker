using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooker.Data
{
    public static class RolesData
    {
        private static readonly string[] roles = new[]
        {
            "Admin",
            "Member"
        };

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach(var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var tryCreate = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!tryCreate.Succeeded)
                    {
                        throw new Exception($"Failed to create role: {role}");
                    }
                }
            }
        }
    }
}
