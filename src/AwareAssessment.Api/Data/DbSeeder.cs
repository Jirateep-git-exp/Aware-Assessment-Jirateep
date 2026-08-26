using AwareAssessment.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AwareAssessment.Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        await db.Database.EnsureCreatedAsync();
        if (await db.Products.AnyAsync()) return;

        var categories = new[]
        {
            new Category { Id = 1, Name = "Accessories" },
            new Category { Id = 2, Name = "Monitor" },
            new Category { Id = 3, Name = "Gaming Gear" }
        };

        var activates = new[]
        {
            new IsActive { Id = 1, Name = "Active" },
            new IsActive { Id = 2, Name = "Inactive" }
        };

        db.Categories.AddRange(categories);
        db.IsActive.AddRange(activates);
        db.Products.AddRange(
            new Product { Id = 1, Name = "Mechanical Keyboard", CategoryId = 1, Price = 1890, Stock = 20, IsActiveId = 1, CreatedAt = new DateTime(2026, 1, 10) },
            new Product { Id = 2, Name = "Wireless Mouse", CategoryId = 1, Price = 990, Stock = 35, IsActiveId = 1, CreatedAt = new DateTime(2026, 1, 12) },
            new Product { Id = 3, Name = "27-inch Monitor", CategoryId = 2, Price = 7990, Stock = 12, IsActiveId = 1, CreatedAt = new DateTime(2026, 2, 5) },
            new Product { Id = 4, Name = "USB-C Hub", CategoryId = 1, Price = 1290, Stock = 25, IsActiveId = 1, CreatedAt = new DateTime(2026, 2, 20) },
            new Product { Id = 5, Name = "Laptop Stand", CategoryId = 1, Price = 1590, Stock = 18, IsActiveId = 1, CreatedAt = new DateTime(2026, 3, 1) },
            new Product { Id = 6, Name = "Microphone", CategoryId = 1, Price = 560, Stock = 18, IsActiveId = 2, CreatedAt = new DateTime(2026, 3, 23) },
            new Product { Id = 7, Name = "Gaming Mouse", CategoryId = 3, Price = 1299, Stock = 15, IsActiveId = 1, CreatedAt = new DateTime(2026, 8, 14) },
            new Product { Id = 8, Name = "Gaming Headset", CategoryId = 3, Price = 2999, Stock = 10, IsActiveId = 2, CreatedAt = new DateTime(2026, 7, 25) }
        );

        await db.SaveChangesAsync();
    }
}
