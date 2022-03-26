#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Seasons;

public class DetailsModel : SeasonBaseModel
{
    private readonly Data.MySqlTestRazorContext _context;

    public DetailsModel(Data.MySqlTestRazorContext context)
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
