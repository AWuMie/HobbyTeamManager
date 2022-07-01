namespace HobbyTeamManager.Models;

public class SitePlayer
{
    public int? SiteId { get; set; }
    public Site? Site { get; set; }

    public int? PlayerId { get; set; }
    public Player? Player { get; set; }
}
