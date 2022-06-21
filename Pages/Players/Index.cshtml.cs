#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;
using HobbyTeamManager.Data;
using System.Security.Claims;
using System.Diagnostics;

namespace HobbyTeamManager.Pages.Players;

public class IndexModel : PageModel
{
    private readonly HobbyTeamManagerContext _context;

    public IndexModel(HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public IList<Player> Player { get;set; }

    public int CurrentUserId { get; set; }

    public async Task OnGetAsync()
    {
        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (idClaim != null)
        {
            try
            {
                CurrentUserId = Int32.Parse(idClaim.Value);
            }
            catch (Exception e)
            {
                Debug.WriteLine("ERROR: {0} / Type: {1}", e.Message, e.GetType());
                throw;
            }
        }

        Player = await _context.Players.ToListAsync();
    }
}
