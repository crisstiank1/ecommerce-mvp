namespace ECommerce.Application.DTOs.Orders;

public class CreateOrderRequestDto
{
    public string ShippingAddress { get; set; } = string.Empty;
    public List<CreateOrderItemRequestDto> Items { get; set; } = new();
}