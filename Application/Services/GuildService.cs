using Application.DTOs.Channel;
using Application.DTOs.Guild;
using Application.Interfaces;
using Infrastucture;
using Microsoft.Extensions.Options;

namespace Application.Services;

public class GuildService
{
    private readonly IDiscordApiGuild _discordApiGuild;
    private readonly Authorization _authorizationToken;

    public GuildService(IDiscordApiGuild discordApiGuild, IOptions<Authorization> authorizationToken)
    {
        _discordApiGuild = discordApiGuild;
        _authorizationToken = authorizationToken.Value;
    }

    public async Task<GuildResponce> CreateGuild(GuildRequest guild)
    {
        return await _discordApiGuild.CreateGuild(guild, _authorizationToken.Token);
    }

    public async Task<GuildResponce> UpdateGuild(string guildId, GuildRequest guild)
    {
        return await _discordApiGuild.UpdateGuild(guildId, guild, _authorizationToken.Token);
    }

    public async Task DeleteGuild(string guildId)
    {
        await _discordApiGuild.DeleteGuild(guildId, _authorizationToken.Token);
    }

    public async Task<List<GuildResponce>> GetUsersGuilds()
    {
        return await _discordApiGuild.GetUsersGuilds(_authorizationToken.Token);
    }

    /*public async Task<List<ChannelResponse>> GetGuildChannels(string guildId)
    {
        return await _discordApiGuild.GetGuildChannels(guildId, _authorizationToken.Token);
    }*/
    
    public async Task<List<GuildMember>> GetGuildMembers (string guildId,  int limit, ulong after)
    {
        return await _discordApiGuild.GetGuildMembers(guildId, limit, after, _authorizationToken.Token);
    }
}