using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestsApi.Domain.PlayerQuests;

namespace QuestsApi.Infrastructure.PlayerQuests;

public class PlayerQuestConfiguration : IEntityTypeConfiguration<PlayerQuest>
{
    public void Configure(EntityTypeBuilder<PlayerQuest> builder)
    {
        builder.Property(pq => pq.Id)
            .ValueGeneratedNever();
        
        builder.OwnsMany(pq => pq.CompletionRequirements, b =>
        {
            b.ToTable("PlayerQuestsCompletionRequirements");

            b.WithOwner().HasForeignKey("QuestId");

            b.HasKey("Id", "QuestId");

            b.Property("Id");

            b.Property(r => r.CurrentValue)
                .HasPrecision(18, 2);

            b.HasOne(r => r.QuestRequirement)
                .WithMany()
                .HasForeignKey("QuestId");
        });
        
        builder.Metadata.FindNavigation(nameof(PlayerQuest.CompletionRequirements))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}