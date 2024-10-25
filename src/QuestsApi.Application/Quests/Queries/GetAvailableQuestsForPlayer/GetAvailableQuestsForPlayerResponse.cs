namespace QuestsApi.Application.Quests.Queries.GetAvailableQuestsForPlayer;

public record GetAvailableQuestsForPlayerResponse(List<QuestResponse> Quests);

public record QuestResponse(
    string Title,
    string Description,
    List<CompleteConditionResponse> CompleteConditions,
    List<RewardResponse> Rewards);
    
public record CompleteConditionResponse(string Description, float Value);
public record RewardResponse(string ItemId, float Count);