using MediatR;
using QuestsApi.Application.Common.Interfaces.Persistence;

namespace QuestsApi.Application.Quests.Queries.GetAvailableQuestsForPlayer;

public class GetAvailableQuestsForPlayerHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAvailableQuestsForPlayerQuery, GetAvailableQuestsForPlayerResponse>
{
    public async Task<GetAvailableQuestsForPlayerResponse> Handle(
        GetAvailableQuestsForPlayerQuery request,
        CancellationToken cancellationToken)
    {
        var player = await unitOfWork.Players.GetByIdAsync(request.PlayerId);
        return new GetAvailableQuestsForPlayerResponse(null);
    }
}