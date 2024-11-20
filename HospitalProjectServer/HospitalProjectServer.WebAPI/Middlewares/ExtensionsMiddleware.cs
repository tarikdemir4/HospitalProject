using HospitalProjectServer.Entities.Enums;
using HospitalProjectServer.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace HospitalProjectServer.WebAPI.Middlewares;

public static class ExtensionsMiddleware
{
    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<User>>();
            if (!userManager.Users.Any(p => p.UserName == "admin"))
            {
                User user = new()
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Tarık",
                    LastName = "Demir",
                    IdentityNumber = "11111111111",
                    FullAdress = "istanbul",
                    DateOfBirth = DateOnly.Parse("06.11.1995"),
                    EmailConfirmed = true,
                    IsActive = true,
                    IsDeleted = false,
                    BloodType = "a rh-",
                    UserType = UserType.Admin,
                };
                userManager.CreateAsync(user, "1").Wait();
            }
        }
    }
}
