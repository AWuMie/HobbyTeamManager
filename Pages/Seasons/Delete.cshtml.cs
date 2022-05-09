#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Seasons;

public class DeleteModel : SeasonBaseModel
{
    public DeleteModel(Data.HobbyTeamManagerContext context)
        : base(context) { }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Season = await Context.Seasons
            .Include(s => s.MatchDays)              // eager loading!
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Season = await Context.Seasons.FindAsync(id);

        if (Season != null)
        {
            // get all the related MatchDays and remove them first
            var matchDays = (from md in Context.MatchDays 
                            where md.SeasonId == Season.Id
                            select md).ToList();
            if (matchDays != null && matchDays.Count > 0)
            {
                Context.MatchDays.RemoveRange(matchDays);
            }
            Context.Seasons.Remove(Season);
            
            await Context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
