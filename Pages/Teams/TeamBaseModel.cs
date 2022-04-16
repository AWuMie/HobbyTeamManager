using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Data;

namespace MySqlTestRazor.Pages.Teams;

public class TeamBaseModel : PageModel
{
    public SelectList? TeamColorSL { get; set; }

    public void PopulateTeamColorDropDownList(MySqlTestRazorContext _context,
        object? selectedTeamColorId = null)
    {
        var teamColorQuery = from tc in _context.TeamColors
                                  orderby tc.Id     // sort by Id!
                                  select tc;

        var items = teamColorQuery.AsNoTracking().ToList();

        TeamColorSL = new SelectList(items,
            "TeamColorId", "Name", selectedTeamColorId);
    }
}
