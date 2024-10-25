using Microsoft.AspNetCore.Mvc;
using QuestsApi.Contracts.PlayerQuests;

namespace QuestsApi.Api.Controllers;

[ApiController]
[Route("api/v1/players/{playerId}/quests")]
public class PlayerQuestController : ControllerBase
{
    [HttpPost]
    [Route("{questId}")]
    public async Task<IActionResult> UpdateQuestProgressAsync(UpdatePlayerQuestRequest request)
    {
        return Ok();
    }
}