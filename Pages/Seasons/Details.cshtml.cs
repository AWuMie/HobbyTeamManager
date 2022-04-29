#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Seasons;

public class DetailsModel : SeasonBaseModel
{
    private readonly Data.HobbyTeamManagerContext _context;

    public DetailsModel(Data.HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Season = await _context.Seasons
            .Include(s => s.MatchDays)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (Season == null)
        {
            return NotFound();
        }

        SelectedYear = Season.Year;
        SelectedMonth = Season.StartMonth;
        SelectedWeekDay = (int)Season.MatchOnDay;

        return Page();
    }
}
