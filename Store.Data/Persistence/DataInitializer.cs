using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Store.Entities.Entities;

namespace Store.Data.Persistence;

public static class DataInitializer {

    public static async Task InitializeAsync(IServiceProvider serviceProvider) {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        string adminEmail    = "admin@example.com";
        string adminPassword = "Admin@123";
        if (await userManager.FindByNameAsync(adminEmail) == null) {
            var adminUser = new ApplicationUser {
                UserName = adminEmail,
                Email    = adminEmail,
                IsAdmin  = true
            };

            await userManager.CreateAsync(adminUser, adminPassword);
        }
    }
}