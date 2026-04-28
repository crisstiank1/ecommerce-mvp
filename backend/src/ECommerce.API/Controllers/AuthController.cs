using ECommerce.Application.DTOs.Auth;
using ECommerce.Application.Interfaces.Persistence;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordHasherService _passwordHasherService;

    public AuthController(
        IApplicationDbContext context,
        IPasswordHasherService passwordHasherService)
    {
        _context = context;
        _passwordHasherService = passwordHasherService;
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(RegisterRequestDto request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName) ||
            string.IsNullOrWhiteSpace(request.Country) ||
            string.IsNullOrWhiteSpace(request.Department) ||
            string.IsNullOrWhiteSpace(request.City) ||
            string.IsNullOrWhiteSpace(request.PhoneNumber) ||
            string.IsNullOrWhiteSpace(request.Address) ||
            string.IsNullOrWhiteSpace(request.Username) ||
            string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new { message = "All required fields must be provided." });
        }

        if (request.Age <= 0)
        {
            return BadRequest(new { message = "Age must be greater than zero." });
        }

        if (request.BirthDate == default)
        {
            return BadRequest(new { message = "BirthDate is required." });
        }

        var normalizedUsername = request.Username.Trim();

        var usernameExists = await _context.Users
            .AnyAsync(x => x.Username == normalizedUsername, cancellationToken);

        if (usernameExists)
        {
            return BadRequest(new { message = "Username is already taken." });
        }

        var user = new User
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Age = request.Age,
            BirthDate = request.BirthDate,
            Country = request.Country.Trim(),
            Department = request.Department.Trim(),
            City = request.City.Trim(),
            PhoneNumber = request.PhoneNumber.Trim(),
            Address = request.Address.Trim(),
            Username = normalizedUsername,
            PasswordHash = _passwordHasherService.HashPassword(request.Password),
            Role = UserRole.Customer
        };

        await _context.AddEntityAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var response = new RegisterResponseDto
        {
            Id = user.Id,
            FullName = $"{user.FirstName} {user.LastName}",
            Username = user.Username,
            Role = user.Role.ToString(),
            Message = "User registered successfully."
        };

        return StatusCode(StatusCodes.Status201Created, response);
    }
}