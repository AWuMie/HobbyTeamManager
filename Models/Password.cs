namespace HobbyTeamManager.Models;

public class Password
{
    public int Id { get; set; }

    public int Salt { get; set; }

    public byte[]? Hash { get; set; }

    // one-to-one relationship Password <-> Player
    public int? PlayerId { get; set; }
    public Player? Player { get; set; }
}
