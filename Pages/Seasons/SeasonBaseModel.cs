//#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlTestRazor.Data;
using MySqlTestRazor.Models;
using System.Globalization;

namespace MySqlTestRazor.Pages.Seasons;

public class SeasonBaseModel : PageModel
{
    private static readonly int _startYear = 2002;
    private static readonly int _endYear = 2031;

    public IDictionary<int, string> years = new Dictionary<int, string>();
    public IDictionary<int, string> months = new Dictionary<int, string>();
    public IDictionary<int, string> weekDays = new Dictionary<int, string>();

    public SelectList YearSL { get; set; }
    public SelectList MonthSL { get; set; }
    public SelectList WeekDaySL { get; set; }

    [BindProperty]
    public Season Season { get; set; }
    [BindProperty]
    public int SelectedYear { get; set; }
    [BindProperty]
    public int SelectedMonth { get; set; }
    [BindProperty]
    public int SelectedWeekDay { get; set; }

    public IList<int> GetExistingYears(MySqlTestRazorContext context)
    {
        var existingSeasons = context.Seasons.ToList();
        IList<int> years = new List<int>();
        foreach (var existingSeason in existingSeasons)
            years.Add(existingSeason.Year);
        return years;
    }

    public void PopulateYearDropDownList(IList<int> existingYears, object? selectedYear = null)
    {
        // FIXED: seasons already in the DB should NOT appear in the dropdown!
        // FIXED: but in Edit the selectedYear should still be available (itself!)
        // availabel years are 2002 .. 2031 - some 30 years ... ;-)
        int sel = 0;
        if (selectedYear != null)
            sel = (int)selectedYear;

        for (int i = _startYear; i < _endYear; i++)
        {
            if ((existingYears.Contains(i)) && !(i == sel))
                continue;

            years.Add(i, i.ToString());
        }
        YearSL = new SelectList(years, "Key", "Value", selectedYear);
    }

    public void PopulateMonthDropDownList(object? selectedMonth = null)
    {
        for (int i = 1; i < 13; i++)
        {
            months.Add(i, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
        }
        MonthSL = new SelectList(months, "Key", "Value", selectedMonth);
    }

    public void PopulateWeekDayDropDownList(object? selectedWeekDay = null)
    {
        for (int i = 0; i < 7; i++)
        {
            weekDays.Add(i, CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)i));
        }
        WeekDaySL = new SelectList(weekDays, "Key", "Value", selectedWeekDay);
    }

    public void PopulateDropDownLists(IList<int> existingYears,
        object? selectedYear = null,
        object? selectedMonth = null,
        object? selectedWeekDay = null)
    {
        PopulateYearDropDownList(existingYears, selectedYear);
        PopulateMonthDropDownList(selectedMonth);
        PopulateWeekDayDropDownList(selectedWeekDay);
    }
}
