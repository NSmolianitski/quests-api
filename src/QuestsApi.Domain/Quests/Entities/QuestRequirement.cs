using QuestsApi.Domain.Common;
using QuestsApi.Domain.Quests.ValueObjects;

namespace QuestsApi.Domain.Quests.Entities;

public class QuestRequirement : Entity<QuestRequirementId>
{
    public string Label { get; private set; }
    public float RequiredValue { get; private set; }
    public float MaxValue { get; private set; }

    private QuestRequirement(QuestRequirementId id, string label, float requiredValue, float maxValue)
        : base(id)
    {
        Label = label;
        RequiredValue = requiredValue;
        MaxValue = maxValue;
    }

    public static QuestRequirement Create(string description, float value, float maxValue) =>
        new(QuestRequirementId.CreateUnique(), description, value, maxValue);
}