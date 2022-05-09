#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Players;

public class DeleteModel : PageModel
{
    private readonly HobbyTeamManager.Data.HobbyTeamManagerContext _context;

    public DeleteModel(HobbyTeamManager.Data.HobbyTeamManagerContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Player = await _context.Players.FindAsync(id);

        if (Player != null)
        {
            _context.Players.Remove(Player);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
