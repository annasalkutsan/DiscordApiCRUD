using Application.DTOs.Channel;
using Application.DTOs.Guild;
using Refit;

namespace Application.Interfaces;

public interface IDiscordApiGuild
{
    [Post("/guilds")]
    Task<GuildResponce> CreateGuild( GuildRequest guild, [Header("Authorization")] string authToken, [Header("accept")] string accept, [Header("accept-language")] string language, 
        [Header("x-debug-options")] string debugOptions, [Header("x-discord-locale")] string discordLocale, [Header("x-discord-timezone")] string discordTimezone, [Header("x-super-properties")] string superProperties);

    [Patch("/guilds/{guildId}")]
    Task<GuildResponce> UpdateGuild(string guildId,  GuildRequest guild, [Header("Authorization")] string authToken);

    [Delete("/guilds/{guildId}")]
    Task DeleteGuild(string guildId, [Header("Authorization")] string authToken);

    [Get("/users/@me/guilds")]
    Task<List<GuildResponce>> GetUsersGuilds([Header("Authorization")] string authToken);
}