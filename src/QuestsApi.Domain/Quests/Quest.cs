using QuestsApi.Domain.Common;
using QuestsApi.Domain.Quests.Entities;
using QuestsApi.Domain.Quests.ValueObjects;

namespace QuestsApi.Domain.Quests;

public sealed class Quest : AggregateRoot<QuestId>
{
    private readonly List<QuestRequirement> _completionRequirements = [];
    private readonly List<QuestRequirement> _accessRequirements = [];
    private readonly List<QuestReward> _rewards = [];

    public string Title { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<QuestRequirement> CompletionRequirements => _completionRequirements.ToList();
    public IReadOnlyList<QuestRequirement> AccessRequirements => _accessRequirements.ToList();
    public IReadOnlyList<QuestReward> QuestRewards => _rewards.ToList();

    private Quest() {}
    
    private Quest(
        QuestId id,
        string title,
        string description,
        List<QuestRequirement> completionRequirements,
        List<QuestRequirement> accessRequirements,
        List<QuestReward> rewards
    ) : base(id)
    {
        Title = title;
        Description = description;
        _completionRequirements = completionRequirements;
        _accessRequirements = accessRequirements;
        _rewards = rewards;
    }

    public static Quest Create(
        string title,
        string description,
        List<QuestRequirement> completeConditions,
        List<QuestRequirement> accessConditions,
        List<QuestReward> rewards
    ) => new(
        QuestId.CreateUnique(),
        title,
        description,
        completeConditions,
        accessConditions,
        rewards
    );
}