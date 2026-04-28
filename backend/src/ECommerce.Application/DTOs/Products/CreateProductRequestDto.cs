namespace ECommerce.Application.DTOs.Products;

public class CreateProductRequestDto
{
    public string Code { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Size { get; set; }
    public string Color { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}