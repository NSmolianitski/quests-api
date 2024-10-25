namespace QuestsApi.Contracts.Quests;

public record CreateQuestRequest(
    string Title,
    string Description,
    List<QuestCondition> CompleteConditions,
    List<QuestCondition> AccessConditions,
    List<QuestReward> Rewards);
    
public record QuestCondition(string Description, float TargetValue);
public record QuestReward(string Id, int Count);