#nullable disable
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HobbyTeamManager.Pages.Sites;

public class HomeModel : BasePageModel
{
    private readonly HobbyTeamManagerContext _context;

    public HomeModel(HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public Site Site { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Site = await _context.Sites.FirstOrDefaultAsync(m => m.Id == id);

        if (Site == null)
        {
            return NotFound();
        }
        
        UpdateBaseProperties(Site);

        return Page();
    }
}
