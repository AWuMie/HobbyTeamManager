#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Sites;

public class EditModel : SiteBaseModel
{
    private readonly HobbyTeamManagerContext _context;

    public EditModel(HobbyTeamManagerContext context)
    {
        _context = context;
    }

    [BindProperty]
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

        ConfirmationModeOptions = PopulateDropDownList(Site.confirmationMode, "Key", "Value",
            Site.ConfirmationModeId);
        MenuPositionOptions = PopulateDropDownList(Site.menuPosition, "Key", "Value",
            Site.MenuPositionId);

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ConfirmationModeOptions = PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                Site.ConfirmationModeId);
            MenuPositionOptions = PopulateDropDownList(Site.menuPosition, "Key", "Value",
                Site.MenuPositionId);
            return Page();
        }

        var oldLogo = _context.Sites
                .AsNoTracking()
                .FirstOrDefault(s => s.Id == Site.Id).Logo;

        if (Request.Form.Files.Count > 0)
        {
            var stream = await GetCheckResizeImageAsync<Site>();
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
            ConfirmationModeOptions = PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                Site.ConfirmationModeId);
            MenuPositionOptions = PopulateDropDownList(Site.menuPosition, "Key", "Value",
                Site.MenuPositionId);
            return Page();
        }

        _context.Attach(Site).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
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
        return _context.Sites.Any(e => e.Id == id);
    }
}
