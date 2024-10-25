using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuestsApi.Api.Controllers.Players;

[ApiController]
[Route("api/v1/players")]
public class PlayerController(
    ISender mediator,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        return Ok();
    }
}