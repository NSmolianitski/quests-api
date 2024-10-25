namespace QuestsApi.Application.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    IPlayerRepository Players { get; }
    IQuestRepository Quests { get; }
    IPlayerQuestRepository PlayerQuests { get; }

    Task SaveChangesAsync();
}