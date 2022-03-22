#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Seasons
{
    public class EditModel : SeasonBaseModel
    {
        private readonly Data.MySqlTestRazorContext _context;

        public EditModel(Data.MySqlTestRazorContext context)
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
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Season == null)
            {
                return NotFound();
            }

            // FIXED: preselection does not work!
            SelectedYear = Season.Year;
            SelectedMonth = Season.StartMonth;
            SelectedWeekDay = (Season.MatchOnDay == DayOfWeek.Sunday) ? 7 : (int)Season.MatchOnDay;

            PopulateDropDownLists(GetExistingYears(_context),
                selectedYear: SelectedYear,
                selectedMonth: SelectedMonth,
                selectedWeekDay: SelectedWeekDay);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Season.Year = SelectedYear;
            Season.StartMonth = SelectedMonth;
            Season.MatchOnDay = (SelectedWeekDay == 7) ? (DayOfWeek)0 : (DayOfWeek)SelectedWeekDay;

            try
            {
                _context.Update(Season);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(Season.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SeasonExists(int id)
        {
            return _context.Seasons.Any(e => e.Id == id);
        }
    }
}
