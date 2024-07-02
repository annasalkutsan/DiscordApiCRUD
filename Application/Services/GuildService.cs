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
    private readonly GuildParams _guildParams;

    public GuildService(IDiscordApiGuild discordApiGuild, IOptions<Authorization> authorizationToken, IOptions<GuildParams> guuildParams)
    {
        _discordApiGuild = discordApiGuild;
        _authorizationToken = authorizationToken.Value;
        _guildParams = guuildParams.Value;
    }

    public async Task<GuildResponce> CreateGuild(GuildRequest guild)
    {
        return await _discordApiGuild.CreateGuild(guild, _authorizationToken.Token,  _guildParams.Accept,
            _guildParams.AcceptLanguage,
            _guildParams.DebugOptions,
            _guildParams.DiscordLocale,
            _guildParams.DiscordTimezone,
            _guildParams.SuperProps);
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
}