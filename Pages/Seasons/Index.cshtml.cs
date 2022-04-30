#nullable disable
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;
using HobbyTeamManager.Utilities;
using HobbyTeamManager.Data;

namespace HobbyTeamManager.Pages.Seasons;

public class IndexModel : BasePageModel
{
    public IndexModel(HobbyTeamManagerContext context)
        : base(context) { }

    public IList<Season> Season { get;set; }

    public async Task OnGetAsync()
    {
        var site = Miscellaneous.GetObjectFromSessionString<Site>(HttpContext);

        //FIXED: Season table shall be sorted ascending by column "Year"
        var seasons = from season in Context.Seasons select season;
        seasons = seasons
            .Include(s => s.MatchDays)          // eager loading!
            .Where(s => s.SiteId == site.Id)
            .OrderBy(season => season.Year);
        Season = await seasons.ToListAsync();
    }
}
