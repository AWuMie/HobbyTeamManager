#nullable disable
using HobbyTeamManager.Models;
using HobbyTeamManager.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HobbyTeamManager.Pages.Players;

public class ImportModel : PlayerBaseModel
{
    public static readonly string successMessage = "SuccessMessage";
    public static readonly string errorMessage = "ErrorMessage";

    public ImportModel(Data.HobbyTeamManagerContext context)
        : base(context) { }

    [BindProperty]
    public IFormFile PlayerJsonFile { get; set; }

    [BindProperty]
    public List<Player> Players { get; set; } = null;

    public void OnGet()
    {
        ViewData[successMessage] = "";
        ViewData[errorMessage] = "";
    }

    public IActionResult OnPostUpload(IFormFile PlayerJsonFile)
    {
        if (PlayerJsonFile == null)
        {
            ViewData[errorMessage] = $"Keine Datei gefunden!";
            return Page();
        }

        string jsonString = null;
        using (var streamReader = new StreamReader(PlayerJsonFile.OpenReadStream(), Encoding.GetEncoding("iso-8859-1")))
        {
            jsonString = streamReader.ReadToEnd();
            if (String.IsNullOrEmpty(jsonString))
            {
                ViewData[errorMessage] = $"Datei \"{PlayerJsonFile.FileName}\" konnte nicht gelesen werden!";
                return Page();
            }
        }

        try
        {
            var result = JsonConvert.DeserializeObject<PlayerImport>(jsonString);
            if (result != null)
            {
                if (!CheckPlayersForRequiredProperties(result.Players))
                {
                    ViewData[errorMessage] = "Nicht alle Spielerdaten erfüllen die Erfordernisse!";
                    return Page();
                }

                Players = result.Players;
                Miscellaneous.SetSessionStringFromObject<List<Player>>(Players, HttpContext);
            }
        }
        catch (Exception)
        {
            ViewData[errorMessage] = $"Datei \"{PlayerJsonFile.FileName}\" konnte nicht gelesen werden!";
            return Page();
        }

        ViewData[successMessage] = $"Datei \"{PlayerJsonFile.FileName}\" geladen";
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostSaveAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Players = Miscellaneous.GetObjectFromSessionString<List<Player>>(HttpContext);

        // check for dublicates!
        // if we don't check for dublicates ...
        // MySqlException: Duplicate entry '' for key 'IX_Players_Emailaddress'
        List<string> mailAdressList = AllExistingDublicatesForThisImport(Players);
        if (mailAdressList.Count > 0)
        {
            string message = "";
            foreach (var mailAddress in mailAdressList)
            {
                message = message + "\"" + mailAddress + "\"" + " , ";
            }
            ViewData[errorMessage] = $"Doppelte Emailadressen: {message}!";
            return Page();
        }

        await Context.Players.AddRangeAsync(Players);
        await Context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private bool CheckPlayersForRequiredProperties(List<Player> players)
    {
        foreach (var player in players)
        {
            if (String.IsNullOrEmpty(player.FirstName) ||
                String.IsNullOrEmpty(player.Emailaddress) ||
                !Miscellaneous.IsMailAddressCorrect(player.Emailaddress) ||
                player.MembershipTypeId < 1 ||
                player.MembershipTypeId > 3)
            {
                return false;   // bail out with first error!
            }
        }
        return true;
    }

    private List<string> AllExistingDublicatesForThisImport(List<Player> players)
    {
        List<string> mailAdressList = new List<string>();

        foreach (var item in Players)
        {
            if (PlayerWithEMailExists(item.Emailaddress))
            {
                mailAdressList.Add(item.Emailaddress);
            }
        }
        return mailAdressList;
    }

    private bool PlayerWithEMailExists(string email)
    {
        return Context.Players.Any(e => e.Emailaddress == email);
    }

    private class PlayerImport
    {
        public List<Player> Players { get; set; }
    }
}
