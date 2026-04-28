using ECommerce.Application.Interfaces.Persistence;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public IQueryable<User> Users => Set<User>();
    public IQueryable<Product> Products => Set<Product>();
    public IQueryable<Order> Orders => Set<Order>();
    public IQueryable<OrderItem> OrderItems => Set<OrderItem>();

    public async Task AddEntityAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
    {
        await Set<T>().AddAsync(entity, cancellationToken);
    }

    public void UpdateEntity<T>(T entity) where T : class
    {
        Set<T>().Update(entity);
    }

    public void RemoveEntity<T>(T entity) where T : class
    {
        Set<T>().Remove(entity);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}