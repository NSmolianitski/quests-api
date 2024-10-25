using QuestsApi.Domain.Common;

namespace QuestsApi.Domain.PlayerQuests.ValueObjects;

public class PlayerQuestRequirementId : ValueObject
{
    public Guid Value { get; }

    private PlayerQuestRequirementId(Guid value)
    {
        Value = value;
    }
    
    public static PlayerQuestRequirementId CreateUnique() => new(Guid.NewGuid());
    public static PlayerQuestRequirementId Create(Guid value) => new(value);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}