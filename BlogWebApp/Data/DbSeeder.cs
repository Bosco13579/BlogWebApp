using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApp.Data
{
    public static class DbSeeder
    {
        public static async Task SeedDb(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            var adminRole = roleManager.Roles.FirstOrDefault(x => x.Name == "admin");
            var userRole = roleManager.Roles.FirstOrDefault(x => x.Name == "user");

            var claim1 = new IdentityRoleClaim<string> { ClaimType = "CanCreatePost", ClaimValue = "CanCreatePost" };
            var claim2 = new IdentityRoleClaim<string> { ClaimType = "CanComment", ClaimValue = "CanComment" };
            var claim3 = new IdentityRoleClaim<string> { ClaimType = "CanEdit", ClaimValue = "CanEdit" };

            if (!context.RoleClaims.Any())
            {
                await roleManager.AddClaimAsync(adminRole, claim1.ToClaim());
                await roleManager.AddClaimAsync(adminRole, claim3.ToClaim());
                await roleManager.AddClaimAsync(userRole, claim2.ToClaim());
            }

            IdentityUser user = new IdentityUser
            {
                UserName = "Member1@email.com",
                Email = "Member1@email.com"
            };

            IdentityUser user1 = new IdentityUser
            {
                UserName = "Customer1@email.com",
                Email = "Customer1@email.com"
            };

            IdentityUser user2 = new IdentityUser
            {
                UserName = "Customer2@email.com",
                Email = "Customer2@email.com"
            };

            IdentityUser user3 = new IdentityUser
            {
                UserName = "Customer3@email.com",
                Email = "Customer3@email.com"
            };

            IdentityUser user4 = new IdentityUser
            {
                UserName = "Customer4@email.com",
                Email = "Customer4@email.com"
            };

            IdentityUser user5 = new IdentityUser
            {
                UserName = "Customer5@email.com",
                Email = "Customer5@email.com"
            };

            IdentityUser user6 = new IdentityUser
            {
                UserName = "test@email.com",
                Email = "test@email.com"
            };

            userManager.CreateAsync(user, "Password123!").Wait();
            userManager.CreateAsync(user1, "Password123!").Wait();
            userManager.CreateAsync(user2, "Password123!").Wait();
            userManager.CreateAsync(user3, "Password123!").Wait();
            userManager.CreateAsync(user4, "Password123!").Wait();
            userManager.CreateAsync(user5, "Password123!").Wait();
            userManager.CreateAsync(user6, "Abc123!").Wait();

            await userManager.AddToRoleAsync(user, "admin");
            await userManager.AddToRoleAsync(user1, "user");
            await userManager.AddToRoleAsync(user2, "user");
            await userManager.AddToRoleAsync(user3, "user");
            await userManager.AddToRoleAsync(user4, "user");
            await userManager.AddToRoleAsync(user5, "user");
            await userManager.AddToRoleAsync(user6, "user");


        }

        public static void SeedDb(UserManager<IdentityUser> userManager)
        {
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            
        }
    }
}