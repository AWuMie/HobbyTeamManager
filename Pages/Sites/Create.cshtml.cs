#nullable disable
using Microsoft.AspNetCore.Mvc;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;
using HobbyTeamManager.Utilities;

namespace HobbyTeamManager.Pages.Sites;

public class CreateModel : SiteBaseModel
{
    public CreateModel(HobbyTeamManagerContext context)
        : base(context) { }

    public IActionResult OnGet()
    {
        ConfirmationModeOptions = Miscellaneous.PopulateDropDownList(Site.confirmationMode, "Key", "Value");
        MenuPositionOptions = Miscellaneous.PopulateDropDownList(Site.menuPosition, "Key", "Value");
        return Page();
    }

    [BindProperty]
    public Site Site { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ConfirmationModeOptions = Miscellaneous.PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                Site.ConfirmationModeId);
            MenuPositionOptions = Miscellaneous.PopulateDropDownList(Site.menuPosition, "Key", "Value",
                Site.MenuPositionId);
            return Page();
        }

        var stream = await FileHelpers.GetCheckResizeImageAsync<Site>(Request, ModelState);
        Site.Logo = stream?.ToArray();

        Context.Sites.Add(Site);
        await Context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
