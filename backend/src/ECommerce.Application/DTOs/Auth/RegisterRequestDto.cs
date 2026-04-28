namespace ECommerce.Application.DTOs.Auth;

public class RegisterRequestDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string Country { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}