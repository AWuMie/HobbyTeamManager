#nullable disable
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages;

public class IndexModel : BasePageModel
{
    private readonly HobbyTeamManagerContext _context;

    public IndexModel(HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public IList<Site> Site { get; set; }

    public async Task OnGetAsync()
    {
        Site = await _context.Sites.ToListAsync();
    }
}
