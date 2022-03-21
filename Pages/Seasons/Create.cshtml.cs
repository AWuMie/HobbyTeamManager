#nullable disable
using Microsoft.AspNetCore.Mvc;
using MySqlTestRazor.Data;
using MySqlTestRazor.Models;
using System.Linq;

namespace MySqlTestRazor.Pages.Seasons
{
    public class CreateModel : SeasonBaseModel
    {
        private readonly MySqlTestRazorContext _context;

        public CreateModel(MySqlTestRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDropDownLists(GetExistingYears(_context));
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropDownLists(GetExistingYears(_context),
                    selectedYear: Season.Year,
                    selectedMonth: Season.StartMonth,
                    selectedWeekDay: Season.MatchOnDay);
                return Page();
            }

            Season.Year = SelectedYear;
            Season.StartMonth = SelectedMonth;
            Season.MatchOnDay = (DayOfWeek)SelectedWeekDay;

            _context.Seasons.Add(Season);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
