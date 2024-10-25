namespace QuestsApi.Contracts.PlayerQuests;

public record UpdatePlayerQuestRequest(
    string PlayerId,
    string QuestId,
    List<UpdatePlayerQuestRequirementRequest> RequirementUpdates
);

public record UpdatePlayerQuestRequirementRequest(string RequirementId, int Progress);