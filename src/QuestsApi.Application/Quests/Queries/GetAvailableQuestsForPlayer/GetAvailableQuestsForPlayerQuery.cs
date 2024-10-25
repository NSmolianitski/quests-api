using MediatR;

namespace QuestsApi.Application.Quests.Queries.GetAvailableQuestsForPlayer;

public record GetAvailableQuestsForPlayerQuery(Guid PlayerId) : IRequest<GetAvailableQuestsForPlayerResponse>;