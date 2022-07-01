using HobbyTeamManager.Data;
using HobbyTeamManager.Models;
using HobbyTeamManager.Pages.Players;
using static HobbyTeamManager.Utilities.PasswordCryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HobbyTeamManager.Pages.Account
{
    public class RegisterModel : PlayerBaseModel
    {
        public RegisterModel(HobbyTeamManagerContext context)
            : base(context) { }

        [BindProperty]
        public Player Player { get; set; }

        [BindProperty]
        [Display(Name = "Passwort")]
        public string Password { get; set; }
       
        [BindProperty]
        [Display(Name = "Passwort bestätigen")]
        public string PasswordConfirm { get; set; }

        [BindProperty]
        public Site Site { get; set; }

        public void OnGet()
        {
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.Equals(Password, PasswordConfirm))
            {
                ModelState.AddModelError(string.Empty, "Passwort und Passwortbestätigung müssen identisch sein");
            }

            if (PlayerWithEmailExists(Player.Emailaddress))
            {
                ModelState.AddModelError(string.Empty, "Spieler (Admin) mit dieser Mailadresse existiert schon!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!string.IsNullOrEmpty(Password))
            {
                var hs = GenerateHashSaltFromPassword(Password);
                Player.PasswordHash = hs.hash;
                Player.PasswordSalt = hs.salt;
            }

            // TODO: send mail to confirm mail address
            //Player.EmailAdressConfirmed = false;
            Player.EmailAdressConfirmed = true;
            Player.IsAdmin = true;
            Player.MembershipTypeId = 1;

            Context.Players.Add(Player);
            Context.Sites.Add(Site);

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new InvalidOperationException("DbUpdateException occurred creating a new admin/user/player.");
            }

            var sp = new SitePlayer();
            sp.PlayerId = Player.Id;
            sp.SiteId = Site.Id;

            Context.SitePlayers.Add(sp);

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new InvalidOperationException("DbUpdateException occurred creating a new admin/user/player.");
            }

            return RedirectToPage("/Index");
        }
    }
}
