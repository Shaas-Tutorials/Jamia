using Jamia.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Jamia.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<ApplicationUser> UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] Roles = { RoleNames.Admin, RoleNames.Student, RoleNames.Teacher };
            foreach (string item in Roles)
            {
                if (!await RoleManager.RoleExistsAsync(item))
                    await RoleManager.CreateAsync(new IdentityRole(item));
            }
            var user = new ApplicationUser { UserName = "Jamia_Admin@jamia.com", Email = "Jamia_Admin@jamia.com" };
            await UserManager.CreateAsync(user, "Jamia_Admin@jamia.com");
            await UserManager.AddToRoleAsync(user, RoleNames.Admin);
        }
    }
}
