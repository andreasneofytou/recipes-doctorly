using Microsoft.AspNetCore.Identity;
using RecipesAPI.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace RecipesAPI.DBContexts
{
    public static class SeedData
    {
        private static RoleManager<Role> roleManager;
        private static UserManager<User> userManager;

        internal static void Initialise(IServiceProvider provider)
        {
            roleManager = provider.GetService<RoleManager<Role>>();
            userManager = provider.GetService<UserManager<User>>();

            CreateRoles();
            CreateUsers();
            var user = userManager.FindByEmailAsync("admin@recipes.com").Result;
            if (user == null) return;
            if (roleManager.RoleExistsAsync("Superuser").Result && roleManager.RoleExistsAsync("Admin").Result)
            {
                _ = userManager.AddToRolesAsync(user, new List<string> { "Admin", "Superuser" }).Result;
            }
        }

        private static void CreateRoles()
        {
            var roles = new List<string> { "Superuser", "Admin", "AppUser" };

            foreach (var role in roles)
            {
                var result = roleManager.RoleExistsAsync(role).Result;
                if (!result)
                {
                    Role newRole = new Role(role);
                    _ = roleManager.CreateAsync(newRole).Result;
                }
            }
        }

        private static void CreateUsers()
        {
            var user = new User
            {
                Email = "admin@recipes.com",
                UserName = "admin@recipes.com",
                EmailConfirmed = true,
                FirstName = "Andreas",
                LastName = "Neofytou"
            };
            var res = userManager.CreateAsync(user, "indigohome67").Result;

        }
    }

}
