#nullable disable
using Microsoft.AspNetCore.Mvc;
using HobbyTeamManager.Models;
using HobbyTeamManager.Utilities;

namespace HobbyTeamManager.Pages.Players;

public class CreateModel : PlayerBaseModel
{
    public CreateModel(Data.HobbyTeamManagerContext context)
        : base(context) { }

    public IActionResult OnGet()
    {
        PopulateMemberTypeDropDownList(Context);
        return Page();
    }

    [BindProperty]
    public Player Player { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            PopulateMemberTypeDropDownList(Context);
            return Page();
        }

        var stream = await FileHelpers.GetCheckResizeImageAsync<Player>(Request, ModelState);
        Player.ProfilePicture = stream?.ToArray();

        // FIXED: Player Create does not save selected membership type!
        Player.MembershipType =
            Context.MembershipTypes.FirstOrDefault(
                x => x.Id == Player.MembershipTypeId);

        Context.Players.Add(Player);
        await Context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
