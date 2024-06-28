using Application.DTOs.Channel;
using Application.Interfaces;
using Infrastucture;
using Microsoft.Extensions.Options;

namespace Application.Services;

public class ChannelService
{
    private readonly IDiscordApiChannel _discordApiChannel;
    private readonly Authorization _authorizationToken;

    public ChannelService(IDiscordApiChannel discordApiChannel, IOptions<Authorization> authorizationToken)
    {
        _discordApiChannel = discordApiChannel;
        _authorizationToken = authorizationToken.Value;
    }

    public async Task<ChannelResponse> CreateChannel(string guildId, ChannelRequest channel)
    {
        return await _discordApiChannel.CreateChannel(guildId, channel, _authorizationToken.Token);
    }

    public async Task<ChannelResponse> UpdateChannel(string channelId, ChannelRequest channel)
    {
        return await _discordApiChannel.UpdateChannel(channelId, channel, _authorizationToken.Token);
    }

    public async Task DeleteChannel(string channelId)
    {
        await _discordApiChannel.DeleteChannel(channelId, _authorizationToken.Token);
    }

    public async Task<List<ChannelResponse>> GetGuildChannels(string guildId)
    {
        return await _discordApiChannel.GetGuildChannels( guildId, _authorizationToken.Token);
    }
}