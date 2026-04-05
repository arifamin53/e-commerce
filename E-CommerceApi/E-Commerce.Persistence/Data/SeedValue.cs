using E_commerce.Domain.Entities;
using E_commerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce.Persistence.Data;

public static class SeedValue
{
    public static void InitialSeedValue(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Name = "arif amin",
            Email = "arifamintantray53@gmail.com",
            ContactNo = "7889424853",
            Salt = "$2a$11$uI/GHqS/buMaPbWnCj7u",
           HashedPassword = "$2a$11$uI/GHqS/buMaPbWnCj7u.eEW4el5yp3mbXITQloYYc86YkDp/Tbxu",
            IsEmailconfirmed = true,
            UserRole = AppEnums.UserRole.Admin,
            IsActive = true,
            IsDeleted = false
        });

    }
}
