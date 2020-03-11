using Microsoft.AspNetCore.Identity;
using NetCoreWebApiArchitectureDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApiArchitectureDemo.Domain.Data
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                var user = new AppUser
                {
                    UserName = "abc@xyz.com",
                    Email = "abc@xyz.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
