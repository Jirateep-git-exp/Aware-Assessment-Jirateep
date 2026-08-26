using System.ComponentModel.Design;
using AwareAssessment.Api.Data;
using AwareAssessment.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AwareAssessment.Api.Services;

public class ProductService(AppDbContext db) : IProductService
{
    public async Task<IReadOnlyList<ProductResponse>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        // Optional bonus: JOIN Products with Categories.
        return await db.Products
            .AsNoTracking()
            // JOIN Products กับ Categories
            .Join(
                db.Categories.AsNoTracking(),
                product => product.CategoryId,
                category => category.Id,
                (product, category) => new
                {
                    Product = product,
                    Category = category
                })

            // JOIN ผลลัพธ์ด้านบนกับ IsActive
            .Join(
                db.IsActive.AsNoTracking(),
                x => x.Product.IsActiveId,
                active => active.Id,
                (x, active) => new ProductResponse
                {
                    Id = x.Product.Id,
                    Name = x.Product.Name,
                    Category = x.Category.Name,
                    Price = x.Product.Price,
                    Stock = x.Product.Stock,
                    IsActive = active.Name,
                    CreatedAt = x.Product.CreatedAt
                })
            .OrderBy(p => p.Id)
            .ToListAsync(cancellationToken);
    }
}
