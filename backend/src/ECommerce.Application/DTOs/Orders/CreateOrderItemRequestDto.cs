namespace ECommerce.Application.DTOs.Orders;

public class CreateOrderItemRequestDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}