namespace QuestsApi.Contracts.Quests;

public record QuestResponse(
    string Id,
    string Title,
    string Description,
    List<QuestCondition> CompleteConditions,
    List<QuestCondition> AccessConditions,
    List<QuestReward> Rewards);