namespace MySqlTestRazor.Models;

public class Season
{
    public int Id { get; set; }

    public int Year { get; set; }

    public int StartMonth { get; set; }
    //string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(StartMonth);

    public DayOfWeek MatchOnDay { get; set; }

    //public IList<MatchDay>? MatchDays { get; set; }
}
