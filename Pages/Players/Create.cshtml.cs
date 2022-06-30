#nullable disable
using Microsoft.AspNetCore.Mvc;
using HobbyTeamManager.Models;
using HobbyTeamManager.Utilities;
using static HobbyTeamManager.Utilities.PasswordCryptography;
using Microsoft.EntityFrameworkCore;

namespace HobbyTeamManager.Pages.Players;

// Ideas about creating/registering players/users.
// - there is initially one administrator with FirstName "Admin" and Emailaddress "admin@hobbyteammanager.com"
// - the hardcoded "Admin" password shall be changed at first log-in
// - only admins can create a site
// - admins can only edit "THEIR" site, not any other site.
// - admins can give admin privileges to other users/players (for their site)
// - on the "Register" page ask whether the registrant wants to be
//   - an admin to create a new site, therefore additionally ask for a new(?) site name
//   - a player/user which registers to a site with the site selectable from a dropdown

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
    public string PasswordConfirm { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!string.Equals(Password, PasswordConfirm))
        {
            ModelState.AddModelError(string.Empty, "Passwort und Passwortbestätigung müssen identisch sein");
        }

        if (PlayerWithEmailExists(Player.Emailaddress))
        {
            ModelState.AddModelError(string.Empty, "Spieler mit dieser Mailadresse existiert schon!");
        }

        // FIXED: check for existing player with same mailaddress!
        if (!ModelState.IsValid)
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
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("DbUpdateException occurred creating a new user/player.");
        }

        return RedirectToPage("./Index");
    }
}
