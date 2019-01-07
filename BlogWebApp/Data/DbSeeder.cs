using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BlogWebApp.Data
{
    public static class DbSeeder
    {
        public static void SeedDb(UserManager<IdentityUser> userManager, IServiceProvider serviceProvider) 
        {
            CreateUserRoles(serviceProvider).Wait();
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
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
        }

         private static async Task CreateUserRoles(IServiceProvider serviceProvider)
         {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            String[] roles = { "Admin", "Mod", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roles)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            IdentityUser user = await UserManager.FindByEmailAsync("Member1@email.com");
            await UserManager.AddToRoleAsync(user, "Admin");

         }

        /*private static void SeedPeople(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.People.Add(
                new Person() { Name = "Member1" }
                );
            context.SaveChanges();
        }*/
    }
}
