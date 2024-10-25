using QuestsApi.Domain.Common;
using QuestsApi.Domain.PlayerQuests.ValueObjects;
using QuestsApi.Domain.Quests;
using QuestsApi.Domain.Quests.Entities;

namespace QuestsApi.Domain.PlayerQuests.Entities;

public class PlayerQuestCompletionRequirement : Entity<PlayerQuestRequirementId>
{
    public QuestRequirement QuestRequirement { get; private set; }
    public float CurrentValue { get; private set; }

    private PlayerQuestCompletionRequirement() { }
    
    private PlayerQuestCompletionRequirement(
        PlayerQuestRequirementId id,
        QuestRequirement requirement,
        float currentValue
    ) : base(id)
    {
        QuestRequirement = requirement;
        CurrentValue = currentValue;
    }

    public static PlayerQuestCompletionRequirement CreateUnique(QuestRequirement requirement, float progress) =>
        new(PlayerQuestRequirementId.CreateUnique(), requirement, progress);

    public bool IsCompleted() => CurrentValue >= QuestRequirement.RequiredValue;

    public void UpdateProgress(float value)
    {
        if (value <= CurrentValue)
            throw new InvalidOperationException("New value is lower or equal to the current value.");

        if (value > QuestRequirement.MaxValue)
            throw new InvalidOperationException("New value is higher than the max value.");

        CurrentValue = value;
    }
}