using QuestsApi.Domain.Common;
using QuestsApi.Domain.PlayerQuests.Entities;
using QuestsApi.Domain.PlayerQuests.ValueObjects;
using QuestsApi.Domain.Players.ValueObjects;
using QuestsApi.Domain.Quests.ValueObjects;

namespace QuestsApi.Domain.PlayerQuests;

public sealed class PlayerQuest(PlayerQuestId id) : AggregateRoot<PlayerQuestId>(id)
{
    private readonly List<PlayerQuestCompletionRequirement> _completionRequirements = [];

    public PlayerId PlayerId { get; private set; }
    public QuestId QuestId { get; private set; }
    public PlayerQuestStatus Status { get; private set; }

    public IReadOnlyList<PlayerQuestCompletionRequirement> CompletionRequirements => _completionRequirements.ToList();

    public void UpdateProgress(PlayerQuestRequirementId requirementId, float value)
    {
        if (Status == PlayerQuestStatus.Finished)
            throw new InvalidOperationException("Cannot update progress of a finished quest.");

        var requirement = _completionRequirements
            .FirstOrDefault(r => r.Id == requirementId);
        if (requirement is null)
            throw new ArgumentException("Invalid requirement ID.");

        requirement.UpdateProgress(value);

        if (Status == PlayerQuestStatus.Accepted)
            Status = PlayerQuestStatus.InProgress;

        if (requirement.IsCompleted() && AreAllRequirementsCompleted())
            Status = PlayerQuestStatus.Completed;
    }

    public bool AreAllRequirementsCompleted() =>
        _completionRequirements.All(r => r.IsCompleted());
}