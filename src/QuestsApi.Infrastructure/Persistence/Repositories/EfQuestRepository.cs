using Microsoft.EntityFrameworkCore;
using QuestsApi.Application.Common.Interfaces.Persistence;
using QuestsApi.Domain.PlayerQuests;
using QuestsApi.Domain.Players.ValueObjects;
using QuestsApi.Domain.Quests;

namespace QuestsApi.Infrastructure.Persistence;

public class EfQuestRepository(QuestsApiDbContext context) : IQuestRepository
{
    public async Task<Quest> Add(Quest quest)
    {
        context.Quests.Add(quest);
        return quest;
    }

    // public async Task<List<Quest>> GetAvailableForPlayer(PlayerId playerId, List<>)
    // {
    //     var playerQuests = await context.PlayerQuests
    //         .Where(pq => pq.PlayerId == playerId)
    //         .Select(pq => pq.QuestId)
    //         .ToListAsync();
    //
    //     return await context.Quests
    //         .Include(q => q.AccessRequirements)
    //         .Where(q =>
    //             !playerQuests.Contains(q.Id) &&
    //             q.AccessRequirements.All(ar =>
    //                 (ar.ComparisonOperator is ComparisonOperator.GreaterThan && playerLevel > ar.Value) ||
    //                 (ar.ComparisonOperator is ComparisonOperator.GreaterThanOrEqual && playerLevel >= ar.Value) ||
    //                 (ar.ComparisonOperator is ComparisonOperator.LessThan && playerLevel < ar.Value) ||
    //                 (ar.ComparisonOperator is ComparisonOperator.LessThanOrEqual && playerLevel <= ar.Value) ||
    //                 (ar.ComparisonOperator is ComparisonOperator.Equal && playerLevel == ar.Value) ||
    //                 (ar.Label is "CompletedQuestId" &&
    //                  context.PlayerQuests.Any(pq =>
    //                      pq.PlayerId == playerId && pq.QuestId == ar.Value && pq.Status == PlayerQuestStatus.Finished))
    //             ))
    //         .ToListAsync();
    // }
}