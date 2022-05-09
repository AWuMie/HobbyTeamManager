//#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;
using System.Globalization;

namespace HobbyTeamManager.Pages.Seasons;

public class SeasonBaseModel : BasePageModel
{
    private static readonly int _startYear = 2002;
    private static readonly int _endYear = 2031;

    public IDictionary<int, string> years = new Dictionary<int, string>();
    public IDictionary<int, string> months = new Dictionary<int, string>();
    public IDictionary<int, string> weekDays = new Dictionary<int, string>();

    public SeasonBaseModel(HobbyTeamManagerContext context)
        : base(context){ }

    public SelectList? YearSL { get; set; }
    public SelectList? MonthSL { get; set; }
    public SelectList? WeekDaySL { get; set; }

    [BindProperty]
    public Season? Season { get; set; }

    [BindProperty]
    public int SelectedYear { get; set; }

    [BindProperty]
    public int SelectedMonth { get; set; }

    [BindProperty]
    public int SelectedWeekDay { get; set; }

    public IList<int>? GetExistingYears(HobbyTeamManagerContext context)
    {
        if (context.Seasons == null)
        {
            return null;
        }
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
        // available years are 2002 .. 2031 - some 30 years ... ;-)
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
        for (int i = 1; i < 8; i++)
        {
            if (i != 7)
                weekDays.Add(i, CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)i));
            else
                weekDays.Add(i, CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)0));
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

    /// <summary>
    /// Get the nth MatchDay of the specified month in the present season.
    /// There should NOT be more that 5 Fridays (or any other weekday) in a month
    /// </summary>
    /// <param name="month">The specified month</param>
    /// <param name="n">Zero based index - max = 5</param>
    /// <returns></returns>
    public MatchDay? GetNthWeekDayOfMonth(Season season, int month, int n)
    {
        if (season == null || season.MatchDays == null)
            return null;

        var matchDays = from md in season.MatchDays
                        where md.Date.Month == month
                        select md;

        try
        {
            return matchDays.ElementAt(n);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
