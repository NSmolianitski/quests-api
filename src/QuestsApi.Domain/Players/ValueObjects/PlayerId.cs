using QuestsApi.Domain.Common;

namespace QuestsApi.Domain.Players.ValueObjects;

public sealed class PlayerId : ValueObject
{
    public Guid Value { get; }
    
    private PlayerId(Guid value)
    {
        Value = value;
    }
    
    public static PlayerId CreateUnique() => new(Guid.NewGuid());
    public static PlayerId Create(Guid value) => new(value);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}