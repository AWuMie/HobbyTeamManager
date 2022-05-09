#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Seasons;

public class EditModel : SeasonBaseModel
{
    public EditModel(Data.HobbyTeamManagerContext context)
        : base(context) { }

    ////////////////////////////////////////////////////////////////////////
    // we do not want Seasons to be edited, because all related Matchdays //
    // would need to be updated as well - maybe later - for now delete    //
    // the unwanted Season and create a new one                           //
    ////////////////////////////////////////////////////////////////////////
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IActionResult> OnGetAsync(int? id)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        throw new NotImplementedException();

        //if (id == null)
        //{
        //    return NotFound();
        //}

        //Season = await _context.Seasons
        //    .FirstOrDefaultAsync(m => m.Id == id);

        //if (Season == null)
        //{
        //    return NotFound();
        //}

        //// FIXED: preselection does not work!
        //SelectedYear = Season.Year;
        //SelectedMonth = Season.StartMonth;
        //SelectedWeekDay = Season.MatchOnDay;

        //PopulateDropDownLists(GetExistingYears(_context),
        //    selectedYear: SelectedYear,
        //    selectedMonth: SelectedMonth,
        //    selectedWeekDay: SelectedWeekDay);

        //return Page();
    }

    ////////////////////////////////////////////////////////////////////////
    // we do not want Seasons to be edited, because all related Matchdays //
    // would need to be updated as well - maybe later - for now delete    //
    // the unwanted Season and create a new one                           //
    ////////////////////////////////////////////////////////////////////////

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IActionResult> OnPostAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        throw new NotImplementedException();

        //if (!ModelState.IsValid)
        //{
        //    return Page();
        //}

        //Season.Year = SelectedYear;
        //Season.StartMonth = SelectedMonth;
        //Season.MatchOnDay = SelectedWeekDay;

        //try
        //{
        //    _context.Update(Season);
        //    await _context.SaveChangesAsync();
        //}
        //catch (DbUpdateConcurrencyException)
        //{
        //    if (!SeasonExists(Season.Id))
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        throw;
        //    }
        //}

        //return RedirectToPage("./Index");
    }

    private bool SeasonExists(int id)
    {
        return Context.Seasons.Any(e => e.Id == id);
    }
}
