using QuestsApi.Domain.Common;

namespace QuestsApi.Domain.Quests.ValueObjects;

public class QuestReward : ValueObject
{
    public string RewardId { get; }
    public float Count { get; }
    
    private QuestReward(string rewardId, float count)
    {
        RewardId = rewardId;
        Count = count;
    }
    
    public static QuestReward Create(string rewardId, float count) => new(rewardId, count);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return RewardId;
        yield return Count;
    }
}