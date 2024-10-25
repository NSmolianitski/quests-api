using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestsApi.Application.Quests.Queries.GetAvailableQuestsForPlayer;
using QuestsApi.Contracts.Quests;

namespace QuestsApi.Api.Controllers.Quests;

[ApiController]
[Route("api/v1/quests")]
public class QuestController(
    ISender mediator,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAvailableQuests(GetAvailableQuestsForPlayerRequest request)
    {
        var query = mapper.Map<GetAvailableQuestsForPlayerQuery>(request);
        var response = await mediator.Send(query);
        return Ok(response);
    }
}