using Application.DTOs.Channel;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Application.Interfaces;

public interface IDiscordApiChannel
{
    [Post("/guilds/{guildId}/channels")]
    Task<ChannelResponse> CreateChannel(string guildId, [FromBody] ChannelRequest channel, [Header("Authorization")] string authToken);

    [Patch("/channels/{channelId}")]
    Task<ChannelResponse> UpdateChannel(string channelId, [FromBody] ChannelRequest channel, [Header("Authorization")] string authToken);
    
    [Delete("/channels/{channelId}")]
    Task DeleteChannel(string channelId, [Header("Authorization")] string authToken);

    [Get("/guilds/{guildId}/channels")]
    Task<List<ChannelResponse>> GetGuildChannels(string guildId, [Header("Authorization")] string authToken);
}