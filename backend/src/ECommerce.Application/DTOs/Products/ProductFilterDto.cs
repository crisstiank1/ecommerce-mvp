namespace ECommerce.Application.DTOs.Products;

public class ProductFilterDto
{
    public string? Search { get; set; }
    public string? Code { get; set; }
    public int? Size { get; set; }
    public string? Color { get; set; }
}