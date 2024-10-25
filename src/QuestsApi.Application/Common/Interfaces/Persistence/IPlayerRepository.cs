using QuestsApi.Domain.Players;

namespace QuestsApi.Application.Common.Interfaces.Persistence;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetAllAsync();
    Task<Player> GetByIdAsync(Guid id);
    Player Add(Player player);
}