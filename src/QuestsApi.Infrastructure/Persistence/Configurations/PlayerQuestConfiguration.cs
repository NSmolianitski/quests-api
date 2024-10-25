using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestsApi.Domain.PlayerQuests;
using QuestsApi.Domain.PlayerQuests.ValueObjects;
using QuestsApi.Domain.Players.ValueObjects;
using QuestsApi.Domain.Quests.ValueObjects;

namespace QuestsApi.Infrastructure.Configurations;

public class PlayerQuestConfiguration : IEntityTypeConfiguration<PlayerQuest>
{
    public void Configure(EntityTypeBuilder<PlayerQuest> builder)
    {
        ConfigurePlayerQuestTable(builder);
        ConfigureConditionsTable(builder);
    }

    private void ConfigurePlayerQuestTable(EntityTypeBuilder<PlayerQuest> builder)
    {
        builder.ToTable("PlayerQuests");

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PlayerQuestId.Create(value)
            );

        builder.Property(q => q.PlayerId)
            .HasConversion(
                id => id.Value,
                value => PlayerId.Create(value)
            );

        builder.Property(q => q.QuestId)
            .HasConversion(
                id => id.Value,
                value => QuestId.Create(value));
    }

    private void ConfigureConditionsTable(EntityTypeBuilder<PlayerQuest> builder)
    {
        builder.OwnsMany(q => q.CompletionRequirements, b =>
        {
            b.ToTable("PlayerQuestsConditions");

            b.WithOwner()
                .HasForeignKey("PlayerQuestId");

            b.HasKey("Id", "PlayerQuestId");

            b.Property(c => c.Id)
                .HasColumnName("CompleteConditionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => PlayerQuestRequirementId.Create(value)
                );

            b.Property(c => c.CurrentValue)
                .HasPrecision(18, 2);
        });
    }
}