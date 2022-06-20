#nullable disable
using Microsoft.AspNetCore.Mvc;
using HobbyTeamManager.Models;
using HobbyTeamManager.Utilities;
using static HobbyTeamManager.Utilities.PasswordCryptography;

namespace HobbyTeamManager.Pages.Players;

// Ideas about creating/registering players/users.
// - there is initially one administrator with FirstName "Admin" and Emailaddress "admin@hobbyteammanager.com"
// - only admins can create Sites
// - on the "Register" page ask whether the registrant wants to be
//   - an admin to create a new site, therefore additionally ask for a new(?) site name
//   - a player/user with registers to a site with the site selectable from a dropdown

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

    [BindProperty]
    public string Password { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        // FIXED: check for existing player with same mailaddress!
        if (!ModelState.IsValid || PlayerWithEmailExists(Player.Emailaddress))
        {
            PopulateMemberTypeDropDownList(Context);
            return Page();
        }

        var stream = await FileHelpers.GetCheckResizeImageAsync<Player>(Request, ModelState);
        Player.ProfilePicture = stream?.ToArray();

        // FIXED: hash the password if not empty!
        if (!string.IsNullOrEmpty(Password))
        {
            var hs = GenerateHashSaltFromPassword(Password);
            Player.PasswordHash = hs.hash;
            Player.PasswordSalt = hs.salt;
        }

        Context.Players.Add(Player);
        await Context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private bool PlayerWithEmailExists(string email)
    {
        return Context.Players.Any(p => p.Emailaddress == email);
    }
}
