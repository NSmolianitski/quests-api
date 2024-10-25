using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestsApi.Domain.Quests;
using QuestsApi.Domain.Quests.ValueObjects;

namespace QuestsApi.Infrastructure.Configurations;

public class QuestConfiguration : IEntityTypeConfiguration<Quest>
{
    public void Configure(EntityTypeBuilder<Quest> builder)
    {
        ConfigureQuestTable(builder);
        ConfigureCompleteConditionsTable(builder);
        ConfigureAccessConditionsTable(builder);
        ConfigureRewardsTable(builder);
    }

    private void ConfigureQuestTable(EntityTypeBuilder<Quest> builder)
    {
        builder.ToTable("Quests");

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => QuestId.Create(value)
            );

        builder.Property(q => q.Title)
            .HasMaxLength(100);

        builder.Property(q => q.Description)
            .HasMaxLength(500);
    }

    private void ConfigureCompleteConditionsTable(EntityTypeBuilder<Quest> builder)
    {
        builder.OwnsMany(q => q.CompletionRequirements, b =>
        {
            b.ToTable("QuestsCompletionRequirements");

            b.WithOwner().HasForeignKey("QuestId");

            b.HasKey("Id", "QuestId");

            b.Property("Id");

            b.Property(c => c.Label)
                .HasMaxLength(500);

            b.Property(c => c.RequiredValue)
                .HasPrecision(18, 2);
        });

        builder.Metadata.FindNavigation(nameof(Quest.CompletionRequirements))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAccessConditionsTable(EntityTypeBuilder<Quest> builder)
    {
        builder.OwnsMany(q => q.AccessRequirements, b =>
        {
            b.ToTable("QuestsAccessConditions");

            b.WithOwner()
                .HasForeignKey("QuestId");

            b.HasKey("Id", "QuestId");

            b.Property("Id");

            b.Property(c => c.Label)
                .HasMaxLength(500);

            b.Property(c => c.RequiredValue)
                .HasPrecision(18, 2);
        });

        builder.Metadata.FindNavigation(nameof(Quest.AccessRequirements))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureRewardsTable(EntityTypeBuilder<Quest> builder)
    {
        builder.OwnsMany(q => q.QuestRewards, b =>
        {
            b.ToTable("QuestsRewards");

            b.WithOwner()
                .HasForeignKey("QuestId");

            b.HasKey("Id");

            b.Property(r => r.RewardId)
                .IsRequired();

            b.Property(r => r.Count)
                .HasPrecision(18, 2)
                .IsRequired();
        });
    }
}