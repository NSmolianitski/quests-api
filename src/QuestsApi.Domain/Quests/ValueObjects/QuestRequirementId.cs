using QuestsApi.Domain.Common;

namespace QuestsApi.Domain.Quests.ValueObjects;

public class QuestRequirementId : ValueObject
{
    public Guid Value { get; private set; }
    
    private QuestRequirementId(Guid value)
    {
        Value = value;
    }
    
    public static QuestRequirementId CreateUnique() => new(Guid.NewGuid());
    public static QuestRequirementId Create(Guid value) => new(value);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}