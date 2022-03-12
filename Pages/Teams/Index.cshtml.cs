#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Teams;

public class IndexModel : TeamBaseModel
{
    private readonly Data.MySqlTestRazorContext _context;

    public IndexModel(Data.MySqlTestRazorContext context)
    {
        _context = context;
    }

    public IList<Team> Team { get;set; }

    public async Task OnGetAsync()
    {
        Team = await _context.Teams.ToListAsync();
    }
}
