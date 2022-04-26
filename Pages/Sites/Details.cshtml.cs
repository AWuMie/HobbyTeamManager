#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Sites;

public class DetailsModel : BasePageModel
{
    public DetailsModel(HobbyTeamManagerContext context)
        : base(context) { }

    public Site Site { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Site = await Context.Sites.FirstOrDefaultAsync(m => m.Id == id);

        if (Site == null)
        {
            return NotFound();
        }
        return Page();
    }
}
