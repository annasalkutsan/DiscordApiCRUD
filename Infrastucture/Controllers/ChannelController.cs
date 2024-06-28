using System.Net;
using Application.DTOs.Channel;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Infrastucture.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChannelController : ControllerBase
{
    private readonly ChannelService _channelService;

    public ChannelController(ChannelService channelService)
    {
        _channelService = channelService;
    }

    [HttpPost("{guildId}/channels")]
    public async Task<IActionResult> CreateChannel(string guildId, [FromBody] ChannelRequest channel)
    {
        var response = await _channelService.CreateChannel(guildId, channel);
        return Ok(response);
    }

    [HttpPatch("/channels/{channelId}")]
    public async Task<IActionResult> UpdateChannel(string channelId, [FromBody] ChannelRequest channel)
    {
        var response = await _channelService.UpdateChannel(channelId, channel);
        return Ok(response);
    }
    
    [HttpDelete("/channels/{channelId}")]
    public async Task<IActionResult> DeleteChannel(string channelId)
    {
        await _channelService.DeleteChannel(channelId);
        return NoContent();
    }

    [HttpGet("{guildId}/channels")]
    public async Task<IActionResult> GetGuildChannels(string guildId)
    {
        var result = await _channelService.GetGuildChannels(guildId);
        return Ok(result);
    }
}