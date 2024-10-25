using QuestsApi.Domain.Quests;

namespace QuestsApi.Application.Common.Interfaces.Persistence;

public interface IQuestRepository
{
    Task<Quest> Add(Quest quest);
}