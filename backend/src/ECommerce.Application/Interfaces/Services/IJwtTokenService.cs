using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services;

public interface IJwtTokenService
{
    string GenerateToken(User user);
    DateTime GetExpiration();
}