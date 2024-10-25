using QuestsApi.Domain.Common;
using QuestsApi.Domain.Players.ValueObjects;

namespace QuestsApi.Domain.Players;

public sealed class Player : Entity<PlayerId>
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    
    private Player() {}
    
    private Player(PlayerId id, string name, int level) : base(id)
    {
        Name = name;
        Level = level;
    }
    
    public static Player Create(string name, int level) => new(PlayerId.CreateUnique(), name, level);
}