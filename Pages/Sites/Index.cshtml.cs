#nullable disable
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Sites;

public class IndexModel : BasePageModel
{
    public IndexModel(HobbyTeamManagerContext context)
        : base(context) { }

    public IList<Site> Site { get;set; }

    public async Task OnGetAsync()
    {
        Site = await Context.Sites.ToListAsync();
    }
}
