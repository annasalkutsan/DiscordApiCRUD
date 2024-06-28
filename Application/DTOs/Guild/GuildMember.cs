namespace Application.DTOs.Guild;

public class GuildMember
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Discriminator { get; set; }

    public List<string> Roles { get; set; }
    public string JoinedAt { get; set; }
    public bool Deaf { get; set; }
    public bool Mute { get; set; }
}