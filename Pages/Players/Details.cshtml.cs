#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly HobbyTeamManager.Data.HobbyTeamManagerContext _context;

        public readonly bool isAdmin;

        public DetailsModel(HobbyTeamManager.Data.HobbyTeamManagerContext context)
        {
            _context = context;
            isAdmin = true;
        }

        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players.FirstOrDefaultAsync(m => m.Id == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
