using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestsApi.Domain.Players;
using QuestsApi.Domain.Players.ValueObjects;

namespace QuestsApi.Infrastructure.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        ConfigurePlayerTable(builder);
    }
    
    private void ConfigurePlayerTable(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PlayerId.Create(value)
            );

        builder.Property(i => i.Name)
            .HasMaxLength(100);
        builder.Property(i => i.Level);
    }
}