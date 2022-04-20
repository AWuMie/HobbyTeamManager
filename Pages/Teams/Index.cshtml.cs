#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Teams;

public class IndexModel : TeamBaseModel
{
    private readonly Data.HobbyTeamManagerContext _context;

    public IndexModel(Data.HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public IList<Team> Team { get;set; } = new List<Team>();

    public async Task OnGetAsync()
    {
        Team = await _context.Teams.ToListAsync();
    }
}
