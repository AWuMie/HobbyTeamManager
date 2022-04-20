#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Players
{
    public class GaleryModel : PageModel
    {
        private readonly HobbyTeamManager.Data.HobbyTeamManagerContext _context;

        public GaleryModel(HobbyTeamManager.Data.HobbyTeamManagerContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; }

        public async Task OnGetAsync()
        {
            Player = await _context.Players.ToListAsync();
        }
    }
}
