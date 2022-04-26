#nullable disable
using Microsoft.AspNetCore.Mvc;
using HobbyTeamManager.Models;

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

        //var stream = await GetCheckResizeImageAsync<Player>("NoImage.jpg");
        var stream = await GetCheckResizeImageAsync<Player>();
        Player.ProfilePicture = stream.ToArray();
        //if (stream == null)
        //{
        //    PopulateMemberTypeDropDownList(_context);
        //    return Page();
        //}

        // FIXED: Player Create does not save selected membership type!
        Player.MembershipType =
            Context.MembershipTypes.FirstOrDefault(
                x => x.Id == Player.MembershipTypeId);

        Context.Players.Add(Player);
        await Context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
