using QuestsApi.Domain.Common;

namespace QuestsApi.Domain.PlayerQuests.ValueObjects;

public sealed class PlayerQuestId : ValueObject
{
    public Guid Value { get; }

    private PlayerQuestId(Guid value)
    {
        Value = value;
    }
    
    public static PlayerQuestId CreateUnique() => new(Guid.NewGuid());
    public static PlayerQuestId Create(Guid value) => new(value);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}