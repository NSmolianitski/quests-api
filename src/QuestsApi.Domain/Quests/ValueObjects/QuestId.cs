using QuestsApi.Domain.Common;

namespace QuestsApi.Domain.Quests.ValueObjects;

public class QuestId : ValueObject
{
    public Guid Value { get; }
    
    private QuestId(Guid value)
    {
        Value = value;
    }

    public static QuestId CreateUnique() => new(Guid.NewGuid());
    public static QuestId Create(Guid value) => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}