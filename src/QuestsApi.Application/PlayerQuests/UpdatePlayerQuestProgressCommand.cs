using MediatR;
using QuestsApi.Domain.PlayerQuests.ValueObjects;
using QuestsApi.Domain.Players.ValueObjects;

namespace QuestsApi.Application.PlayerQuests;

public record UpdatePlayerQuestProgressCommand(
    PlayerId PlayerId,
    PlayerQuestId PlayerQuestId,
    List<PlayerQuestRequirementUpdate> RequirementUpdates
) : IRequest<UpdatePlayerQuestProgressResponse>;

public record PlayerQuestRequirementUpdate(
    PlayerQuestRequirementId PlayerQuestRequirementId,
    float Value);