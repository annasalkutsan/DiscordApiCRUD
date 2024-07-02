using System.Net;
using Application.DTOs.Guild;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Infrastucture.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuildController : ControllerBase
{
    [HttpPost("CreateGuild")]
    public async Task<IActionResult> CreateGuild([FromBody] GuildRequest guild, [FromServices] GuildService guildService)
    {
        var response = await guildService.CreateGuild(guild);
        return Ok(response);
    }

    [HttpPatch("UpdateGuild")]
    public async Task<IActionResult> UpdateGuild(string guildId, [FromBody] GuildRequest guild, [FromServices] GuildService guildService)
    {
        var response = await guildService.UpdateGuild(guildId, guild);
        return Ok(response);
    }

    [HttpDelete("DeleteGuild")]
    public async Task<IActionResult> DeleteGuild(string guildId, [FromServices] GuildService guildService)
    {
        await guildService.DeleteGuild(guildId);
        return NoContent();
    }

    [HttpGet("UsersGuilds")]
    public async Task<IActionResult> GetUsersGuilds([FromServices] GuildService guildService)
    {
        var result = await guildService.GetUsersGuilds();
        return Ok(result);
    }
}