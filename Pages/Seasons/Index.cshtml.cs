#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Seasons;

public class IndexModel : PageModel
{
    private readonly Data.MySqlTestRazorContext _context;

    public IndexModel(Data.MySqlTestRazorContext context)
    {
        _context = context;
    }

    public IList<Season> Season { get;set; }

    public async Task OnGetAsync()
    {
        //FIXED: Season table shall be sorted ascending by column "Year"
        var seasons = from season in _context.Seasons select season;
        seasons = seasons
            .Include(s => s.MatchDays)          // eager loading!
            .OrderBy(season => season.Year);
        Season = await seasons.ToListAsync();
    }
}
