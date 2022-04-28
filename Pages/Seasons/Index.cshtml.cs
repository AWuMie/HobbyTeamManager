#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;
using HobbyTeamManager.Utilities;
using HobbyTeamManager.Data;

namespace HobbyTeamManager.Pages.Seasons;

public class IndexModel : PageModel
{
    private readonly HobbyTeamManagerContext _context;

    public IndexModel(HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public IList<Season> Season { get;set; }

    public async Task OnGetAsync()
    {
        var site = Miscellaneous.GetObjectFromSessionString<Site>(HttpContext);

        //FIXED: Season table shall be sorted ascending by column "Year"
        var seasons = from season in _context.Seasons select season;
        seasons = seasons
            .Include(s => s.MatchDays)          // eager loading!
            .Where(s => s.SiteId == site.Id)
            .OrderBy(season => season.Year);
        Season = await seasons.ToListAsync();
    }
}
