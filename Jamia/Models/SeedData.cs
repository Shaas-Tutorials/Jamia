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
            string[] Roles = { "Admin", "Teacher", "Student" };
            foreach (string item in Roles)
            {
                if (!await RoleManager.RoleExistsAsync(item))
                    await RoleManager.CreateAsync(new IdentityRole(item));
            }
        }
    }
}
