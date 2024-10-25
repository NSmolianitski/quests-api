using MediatR;
using QuestsApi.Domain.Quests;

namespace QuestsApi.Application.Quests.Commands.CreateQuest;

public record CreateQuestCommand(
    string Title,
    string Description,
    List<RequestQuestCondition> CompleteConditions,
    List<RequestQuestCondition> AccessConditions,
    List<RequestQuestReward> Rewards
) : IRequest<Quest>;

public record RequestQuestCondition(string Description, float Value, float MaxValue);
public record RequestQuestReward(string Id, float Count);