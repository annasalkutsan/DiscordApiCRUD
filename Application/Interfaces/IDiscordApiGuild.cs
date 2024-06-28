using Application.DTOs.Channel;
using Application.DTOs.Guild;
using Refit;

namespace Application.Interfaces;

public interface IDiscordApiGuild
{
    [Post("/guilds")]
    Task<GuildResponce> CreateGuild( GuildRequest guild, [Header("Authorization")] string authToken);

    [Patch("/guilds/{guildId}")]
    Task<GuildResponce> UpdateGuild(string guildId,  GuildRequest guild, [Header("Authorization")] string authToken);

    [Delete("/guilds/{guildId}")]
    Task DeleteGuild(string guildId, [Header("Authorization")] string authToken);

    [Get("/users/@me/guilds")]
    Task<List<GuildResponce>> GetUsersGuilds([Header("Authorization")] string authToken);

    /*[Get("/guilds/{guild.id}/channels")]
    Task<List<ChannelResponse>> GetGuildChannels(string guildId, [Header("Authorization")] string authToken);*/
    
    [Get("/guilds/{guildId}/members")]
    Task<List<GuildMember>> GetGuildMembers(string guildId, [Query] int limit, [Query] ulong after, [Header("Authorization")] string authToken);
}