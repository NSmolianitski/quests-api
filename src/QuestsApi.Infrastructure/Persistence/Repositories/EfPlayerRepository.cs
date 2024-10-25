using Microsoft.EntityFrameworkCore;
using QuestsApi.Application.Common.Interfaces.Persistence;
using QuestsApi.Domain.Players;

namespace QuestsApi.Infrastructure.Persistence;

public class EfPlayerRepository(QuestsApiDbContext context) : IPlayerRepository
{
    public async Task<IEnumerable<Player>> GetAllAsync()
    {
        return await context.Players.ToListAsync();
    }

    public async Task<Player> GetByIdAsync(Guid id)
    {
        return await context.Players.SingleAsync(p => p.Id.Value == id);
    }

    public Player Add(Player player)
    {
        return context.Players.Add(player).Entity;
    }
}