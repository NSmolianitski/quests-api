using Microsoft.EntityFrameworkCore;
using QuestsApi.Domain.Common;
using QuestsApi.Domain.PlayerQuests;
using QuestsApi.Domain.Players;
using QuestsApi.Domain.Quests;

namespace QuestsApi.Infrastructure;

public class QuestsApiDbContext(DbContextOptions<QuestsApiDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; init; } = null!;
    public DbSet<Quest> Quests { get; init; } = null!;
    public DbSet<PlayerQuest> PlayerQuests { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestsApiDbContext).Assembly);
        
        AddTestData(modelBuilder);
    }

    private void AddTestData(ModelBuilder modelBuilder)
    {
        
    }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        var changedEntities = ChangeTracker.Entries()
            .Where(e => e is {Entity: BaseEntity, State: EntityState.Added or EntityState.Modified});

        var now = DateTime.UtcNow;
        foreach (var entity in changedEntities)
        {
            var baseEntity = (BaseEntity) entity.Entity;
            if (entity.State == EntityState.Added)
                baseEntity.SetCreatedAt(now);
            baseEntity.SetUpdatedAt(now);
        }
    }
}