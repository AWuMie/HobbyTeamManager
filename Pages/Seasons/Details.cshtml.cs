#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Seasons;

public class DetailsModel : SeasonBaseModel
{
    public DetailsModel(Data.HobbyTeamManagerContext context)
        : base(context) { }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Season = await Context.Seasons
            .Include(s => s.MatchDays)
            .FirstOrDefaultAsync(s => s.Id == id);

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
