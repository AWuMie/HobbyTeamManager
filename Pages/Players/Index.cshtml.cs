#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Players;

public class IndexModel : PageModel
{
    private readonly HobbyTeamManager.Data.HobbyTeamManagerContext _context;

    public IndexModel(HobbyTeamManager.Data.HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public IList<Player> Player { get;set; }

    public async Task OnGetAsync()
    {
        Player = await _context.Players.ToListAsync();
    }
}
