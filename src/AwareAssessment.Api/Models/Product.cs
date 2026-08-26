namespace AwareAssessment.Api.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int IsActiveId { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class IsActive
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string IsActive { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
