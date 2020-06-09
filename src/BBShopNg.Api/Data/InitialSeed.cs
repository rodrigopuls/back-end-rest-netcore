using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BBShopNg.Api.Data
{
public static class InitialSeed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            //var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            //var userExist = await userManager.FindByEmailAsync("sac@bbshop.com.br");
            //if (userExist != null)
            //{
            //    return;
            //};

            ////adding customs roles
            //string[] roleNames = { "Administrador", "Titular", "Membro", "Convidado" };

            //foreach (var roleName in roleNames)
            //{
            //    // creating the roles and seeding them to the database
            //    var roleExist = await roleManager.RoleExistsAsync(roleName);
            //    if (!roleExist)
            //    {
            //        await roleManager.CreateAsync(new ApplicationRole()
            //        {
            //            Name = roleName
            //        });
            //    }
            //};

            //// creating a super user who could maintain the web app
            //var adminUser = new ApplicationUser
            //{
            //    UserName = "sac@bbshop.com.br",
            //    Email = "sac@bbshop.com.br",
            //    EmailConfirmed = true
            //};

            //var result = await userManager.CreateAsync(adminUser, "Inicio01@");
            //if (result.Succeeded)
            //{
            //    // here we assign the new user the "Admin" role 
            //    await userManager.AddToRoleAsync(adminUser, "Administrador");
            //}

            //// create a Titular User
            //var titular = new ApplicationUser
            //{
            //    UserName = "titular@bbshop.com.br",
            //    Email = "titular@bbshop.com.br",
            //    EmailConfirmed = true
            //};

            //result = await userManager.CreateAsync(titular, "Inicio01@");
            //if (result.Succeeded)
            //{
            //    await userManager.AddToRoleAsync(titular, "Titular");
            //}

            //// create a Membro User
            //var member = new ApplicationUser
            //{
            //    UserName = "membro@bbshop.com.br",
            //    Email = "membro@bbshop.com.br",
            //    EmailConfirmed = true
            //};

            //result = await userManager.CreateAsync(member, "Inicio01@");
            //if (result.Succeeded)
            //{
            //    await userManager.AddToRoleAsync(member, "Membro");
            //}

        }
    }
}