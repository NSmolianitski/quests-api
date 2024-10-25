using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestsApi.Domain.Quests;

namespace QuestsApi.Infrastructure.Quests;

public class QuestConfiguration : IEntityTypeConfiguration<Quest>
{
    public void Configure(EntityTypeBuilder<Quest> builder)
    {
        builder.Property(q => q.Id)
            .ValueGeneratedNever();
    }
}