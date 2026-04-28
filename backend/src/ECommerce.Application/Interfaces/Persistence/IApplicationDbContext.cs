using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Persistence;

public interface IApplicationDbContext
{
    IQueryable<User> Users { get; }
    IQueryable<Product> Products { get; }
    IQueryable<Order> Orders { get; }
    IQueryable<OrderItem> OrderItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}