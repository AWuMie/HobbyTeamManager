using HobbyTeamManager.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace HobbyTeamManager.Services;

public static class CookieValidator
{
    public static async Task ValidateAsync(CookieValidatePrincipalContext context)
    {
        if (!await ValidateCookieAsync(context))
        {
            context.RejectPrincipal();
            await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }

    private static async Task<bool> ValidateCookieAsync(CookieValidatePrincipalContext context)
    {
        var claimsPrincipal = context.Principal;

        var uid = (from c in claimsPrincipal.Claims
                   where c.Type == ClaimTypes.NameIdentifier
                   select c.Value).FirstOrDefault();

        if (!int.TryParse(uid, out int userId))
        {
            return false;
        }

        var rowVersionString = (from c in claimsPrincipal.Claims
                                where c.Type == ClaimTypes.UserData
                                select c.Value).FirstOrDefault();

        if (string.IsNullOrEmpty(rowVersionString))
        {
            return false;
        }

        DateTime rowVersion = DateTime.Parse(rowVersionString);

        var dbContext = context.HttpContext.RequestServices.GetRequiredService<HobbyTeamManagerContext>();

        try
        {
            return await dbContext.Players
                .AsNoTracking()
                .Where(a => a.Id == userId)
                .Select(a => a.RowVersion == rowVersion)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
        catch (Exception)
        {
            return false;
        }
    }
}
