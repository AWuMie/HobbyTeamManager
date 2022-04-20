#nullable disable
using Microsoft.AspNetCore.Mvc;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Seasons
{
    public class CreateModel : SeasonBaseModel
    {
        private readonly HobbyTeamManagerContext _context;

        public bool MatchDaysCreated { get; private set; }

        public CreateModel(HobbyTeamManagerContext context)
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
                    //selectedWeekDay: (Season.MatchOnDay == DayOfWeek.Sunday) ? 7 : (int)Season.MatchOnDay);
                return Page();
            }

            Season.Year = SelectedYear;
            Season.StartMonth = SelectedMonth;
            Season.MatchOnDay = SelectedWeekDay;
            //Season.MatchOnDay = (SelectedWeekDay == 7) ? (DayOfWeek) 0 : (DayOfWeek) SelectedWeekDay;

            // first add the Season
            _context.Seasons.Add(Season);
            await _context.SaveChangesAsync();

            // then add the related MatchDays
            Season.MatchDays = GenerateMatchDays(Season.Id, SelectedYear, SelectedMonth, SelectedWeekDay);
            _context.MatchDays.AddRange(Season.MatchDays);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private IList<MatchDay> GenerateMatchDays(int seasonId, int year, int month, int weekDay)
        {
            IList<MatchDay> matchDays = new List<MatchDay>();

            // depending on the start month a 12 month period may be part of two years.
            // Only if a season starts on January, it will stay in one year ;-)
            for (int monthInYear = month; monthInYear <= 12; monthInYear++)
            {
                foreach (var md in GenerateMatchDaysOfMonthInYear(seasonId, year, monthInYear, weekDay))
                {
                    matchDays.Add(md);
                }
            }

            for (int monthInYear = 1; monthInYear <= month-1; monthInYear++)
            {
                foreach (var md in GenerateMatchDaysOfMonthInYear(seasonId, year + 1, monthInYear, weekDay))
                {
                    matchDays.Add(md);
                }
            }

            return matchDays;
        }

        private IEnumerable<MatchDay> GenerateMatchDaysOfMonthInYear(int seasonId, int year, int month, int weekDay)
        {
            int numDaysInMonth = DateTime.DaysInMonth(year, month);
            for (int dayInMonth = 1; dayInMonth <= numDaysInMonth; dayInMonth++)
            {
                var dt = new DateTime(year, month, dayInMonth);
                var correctedWeekDay = (weekDay == 7) ? DayOfWeek.Sunday : (DayOfWeek)weekDay;
                if (dt.DayOfWeek == correctedWeekDay)
                {
                    var matchDay = new MatchDay(dt, seasonId);
                    yield return matchDay;
                }
            }
        }
    }
}
