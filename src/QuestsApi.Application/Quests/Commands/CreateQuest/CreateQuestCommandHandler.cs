using MediatR;
using QuestsApi.Application.Common.Interfaces.Persistence;
using QuestsApi.Domain.Quests;
using QuestsApi.Domain.Quests.Entities;
using QuestsApi.Domain.Quests.ValueObjects;

namespace QuestsApi.Application.Quests.Commands.CreateQuest;

public class CreateQuestCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateQuestCommand, Quest>
{
    public async Task<Quest> Handle(CreateQuestCommand request, CancellationToken cancellationToken)
    {
        var quest = Quest.Create(
            request.Title,
            request.Description,
            request.CompleteConditions
                .ConvertAll(c =>
                    QuestRequirement.Create(c.Description, c.Value, c.MaxValue)),
            request.AccessConditions
                .ConvertAll(c =>
                    QuestRequirement.Create(c.Description, c.Value, c.MaxValue)),
            request.Rewards
                .ConvertAll(r =>
                    QuestReward.Create(r.Id, r.Count)));

        await unitOfWork.Quests.Add(quest);
        await unitOfWork.SaveChangesAsync();
        return quest;
    }
}