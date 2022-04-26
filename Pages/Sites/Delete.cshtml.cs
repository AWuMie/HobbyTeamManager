#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Sites;

public class DeleteModel : BasePageModel
{
    public DeleteModel(HobbyTeamManagerContext context)
        : base(context) { }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Site = await Context.Sites.FindAsync(id);

        if (Site != null)
        {
            Context.Sites.Remove(Site);
            await Context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
