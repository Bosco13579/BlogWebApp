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

            await roleManager.CreateAsync(new IdentityRole("admin"));
            await roleManager.CreateAsync(new IdentityRole("user"));

            var adminRole = roleManager.Roles.FirstOrDefault(x => x.Name == "admin");
            var userRole = roleManager.Roles.FirstOrDefault(x => x.Name == "user");

            var claim1 = new IdentityRoleClaim<string> { ClaimType = "CanCreatePost", ClaimValue = "CanCreatePost" };

            await roleManager.AddClaimAsync(adminRole, claim1.ToClaim());






            //var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();


            //if (!context.Roles.Any())
            //{
            //    await roleMethods.AddRole(new IdentityRole("Admin"));
            //}




            //IdentityUser user = new IdentityUser
            //{
            //    UserName = "Member1@email.com",
            //    Email = "Member1@email.com"
            //};

            //IdentityUser user1 = new IdentityUser
            //{
            //    UserName = "Customer1@email.com",
            //    Email = "Customer1@email.com"
            //};

            //IdentityUser user2 = new IdentityUser
            //{
            //    UserName = "Customer2@email.com",
            //    Email = "Customer2@email.com"
            //};

            //IdentityUser user3 = new IdentityUser
            //{
            //    UserName = "Customer3@email.com",
            //    Email = "Customer3@email.com"
            //};

            //IdentityUser user4 = new IdentityUser
            //{
            //    UserName = "Customer4@email.com",
            //    Email = "Customer4@email.com"
            //};

            //IdentityUser user5 = new IdentityUser
            //{
            //    UserName = "Customer5@email.com",
            //    Email = "Customer5@email.com"
            //};

            //IdentityUser user6 = new IdentityUser
            //{
            //    UserName = "test@email.com",
            //    Email = "test@email.com"
            //};

            //userManager.CreateAsync(user, "Password123!").Wait();
            //userManager.CreateAsync(user1, "Password123!").Wait();
            //userManager.CreateAsync(user2, "Password123!").Wait();
            //userManager.CreateAsync(user3, "Password123!").Wait();
            //userManager.CreateAsync(user4, "Password123!").Wait();
            //userManager.CreateAsync(user5, "Password123!").Wait();
            //userManager.CreateAsync(user6, "Abc123!").Wait();




        }

        public static void SeedDb(UserManager<IdentityUser> userManager)
        {
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
    }
}
        /*
         private static async Task CreateUserRoles(IServiceProvider serviceProvider)
         {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            String[] roles = { "Admin", "Mod", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roles)
            {
               if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            IdentityUser user = await UserManager.FindByEmailAsync("Member1@email.com");
            await UserManager.AddToRoleAsync(user, "Admin");

         }*/

        /*private static void SeedPeople(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.People.Add(
                new Person() { Name = "Member1" }
                );
            context.SaveChanges();
        }
    }
}
*/