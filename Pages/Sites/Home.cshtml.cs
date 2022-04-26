#nullable disable
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HobbyTeamManager.Pages.Sites;

public class HomeModel : BasePageModel
{
    public HomeModel(HobbyTeamManagerContext context)
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

        Utilities.Miscellaneous.SetSessionStringFromObject<Site>(Site, HttpContext);

        return Page();
    }
}
