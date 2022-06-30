using HobbyTeamManager.Data;
using HobbyTeamManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static HobbyTeamManager.Utilities.PasswordCryptography;

namespace HobbyTeamManager.Pages.Account;

public class LoginModel : BasePageModel
{
    public LoginModel(HobbyTeamManagerContext context)
        : base(context) { }

    [BindProperty]
    public string? Email { get; set; }

    [BindProperty]
    public string? Password { get; set; }
    
    [BindProperty]
    public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; }

    public async void OnGetAsync(string? returnUrl = null)
    {
        // to clear existing cookie
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        returnUrl ??= Url.Content("~/");
        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;

        // Something failed. Redisplay the form.
        if (!ModelState.IsValid)
            return Page();

        var user = await AuthenticateUser(Email, Password);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Ungültiger Anmeldeversuch.");
            return Page();
        }

        DateTime dateTime = (DateTime)user.RowVersion;
        string rowVersionString = dateTime.ToString("o");
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer),
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Email, user.Emailaddress),
            new Claim(ClaimTypes.UserData, rowVersionString)
        };

        if (user.IsAdmin)
        {
            claims.Add(new Claim(ClaimTypes.Role, Player.AdminRole));
            claims.Add(new Claim(ClaimTypes.Role, Player.UserRole));
        }
        else
        {
            claims.Add(new Claim(ClaimTypes.Role, Player.UserRole));
        }

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
        {
            IsPersistent = RememberMe
        });

        if (!Url.IsLocalUrl(returnUrl))
        {
            returnUrl = Url.Content("~/");
        }

        return LocalRedirect(returnUrl);
    }

    private async Task<Player?> AuthenticateUser(string? login, string? password)
    {
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            return null;
        }

        var user = await Context.Players
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Emailaddress == login);

        if (user == null)
        {
            return null;
        }

#pragma warning disable CS8601 // Possible null reference assignment.
        HashSalt hashSalt = new()
        {
            hash = user.PasswordHash,
            salt = user.PasswordSalt
        };
#pragma warning restore CS8601 // Possible null reference assignment.

        if (IsPasswordCorrect(password, hashSalt))
        {
            return user;
        }

        return null;
    }
}
