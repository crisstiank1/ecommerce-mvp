using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Persistence;

public interface IApplicationDbContext
{
    IQueryable<User> Users { get; }
    IQueryable<Product> Products { get; }
    IQueryable<Order> Orders { get; }
    IQueryable<OrderItem> OrderItems { get; }

    Task AddEntityAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
    void UpdateEntity<T>(T entity) where T : class;
    void RemoveEntity<T>(T entity) where T : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}