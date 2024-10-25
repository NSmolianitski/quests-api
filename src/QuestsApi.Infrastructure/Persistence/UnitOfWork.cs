using QuestsApi.Application.Common.Interfaces.Persistence;

namespace QuestsApi.Infrastructure;

public class UnitOfWork(
    QuestsApiDbContext context,
    IPlayerRepository playerRepository,
    IQuestRepository questRepository,
    IPlayerQuestRepository playerQuestRepository
) : IUnitOfWork
{
    public IPlayerRepository Players { get; } = playerRepository;
    public IQuestRepository Quests { get; } = questRepository;
    public IPlayerQuestRepository PlayerQuests { get; } = playerQuestRepository;

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}