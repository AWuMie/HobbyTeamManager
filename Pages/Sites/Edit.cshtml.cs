#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;
using HobbyTeamManager.Utilities;

namespace HobbyTeamManager.Pages.Sites;

public class EditModel : SiteBaseModel
{
    public EditModel(HobbyTeamManagerContext context)
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

        ConfirmationModeOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.confirmationMode, "Key", "Value",
            Site.ConfirmationModeId);
        MenuPositionOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.menuPosition, "Key", "Value",
            Site.MenuPositionId);

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ConfirmationModeOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                Site.ConfirmationModeId);
            MenuPositionOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.menuPosition, "Key", "Value",
                Site.MenuPositionId);
            return Page();
        }

        var oldLogo = Context.Sites
                .AsNoTracking()
                .FirstOrDefault(s => s.Id == Site.Id).Logo;

        if (Request.Form.Files.Count > 0)
        {
            var stream = await FileHelpers.GetCheckResizeImageAsync<Site>(Request, ModelState);
            Site.Logo = stream.ToArray();

            if (Site.Logo == null)
                Site.Logo = oldLogo;
        }
        else if (Site.Logo != oldLogo)
        {
            Site.Logo = oldLogo;
        }

        if (Site.TeamColor1 == Site.TeamColor2)
        {
            ConfirmationModeOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                Site.ConfirmationModeId);
            MenuPositionOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.menuPosition, "Key", "Value",
                Site.MenuPositionId);
            return Page();
        }

        Context.Attach(Site).State = EntityState.Modified;

        try
        {
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SiteExists(Site.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool SiteExists(int id)
    {
        return Context.Sites.Any(e => e.Id == id);
    }
}
