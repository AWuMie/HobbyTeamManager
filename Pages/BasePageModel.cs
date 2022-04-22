using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HobbyTeamManager.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Collections;
using HobbyTeamManager.Models;
using HobbyTeamManager.Data;
using Microsoft.EntityFrameworkCore;

namespace HobbyTeamManager.Pages;

public class BasePageModel : PageModel
{
    public string Name { get; set; } = string.Empty;
    public string Motto { get; set; } = string.Empty;
    public string Headline { get; set; } = "Hobby Team Manager";
    public string Headline2 { get; set; } = string.Empty;
    public string Rules { get; set; } = string.Empty;
    public int ConfirmationModeId { get; set; }
    public string TeamColor1 { get; set; } = "#ffffff";    // white
    public string TeamColor2 { get; set; } = "#ff0000";    // red

    public int MenuPositionId { get; set; }
    public string BgColorBody { get; set; } = "#000000";    // black
    public string FgColorBody { get; set; } = "#ffa500";    // orange
    public string BgColorHeader { get; set; } = "#000000";
    public string FgColorHeader { get; set; } = "#ffa500";
    public string BgColorMain { get; set; } = "#000000";
    public string FgColorMain { get; set; } = "#ffa500";
    public string BgColorFooter { get; set; } = "#000000";
    public string FgColorFooter { get; set; } = "#ffa500";

    public void UpdateBaseProperties(Site site)
    {
        Name = site.Name;
        Motto = site.Motto ?? string.Empty;
        Headline = site.Headline;
        Headline2 = site.Headline2 ?? string.Empty;
        Rules = site.Rules ?? string.Empty;
        ConfirmationModeId = site.ConfirmationModeId;
        TeamColor1 = site.TeamColor1;
        TeamColor2 = site.TeamColor2;

        MenuPositionId = site.MenuPositionId;
        BgColorBody = site.BgColorBody;
        FgColorBody = site.FgColorBody;
        BgColorHeader = site.BgColorHeader;
        FgColorHeader = site.FgColorHeader;
        BgColorMain = site.BgColorMain;
        FgColorMain = site.FgColorMain;
        BgColorFooter = site.BgColorFooter;
        FgColorFooter = site.FgColorFooter;
    }

    public void UpdateBaseProperties(HobbyTeamManagerContext context, int siteId)
    {
        if (context.Sites == null)
            return;

        var site = context.Sites
            .AsNoTracking()
            .FirstOrDefault(s => s.Id == siteId);

        if (site == null)
            return;

        UpdateBaseProperties(site);
    }

    public SelectList PopulateDropDownList(IEnumerable collection,
        string value, string data, object? selectedItem = null)
    {
        return new SelectList(collection, value, data, selectedItem);
    }

    public async Task<MemoryStream?> GetCheckResizeImageAsync<T>(/*string noImage*/)
    {
        using var dataStream = new MemoryStream();
        if (Request.Form.Files.Count > 0)
        {
            // links to checks described in "Areas/Identity/Pages/Account/Manage/Index.cshtml.cs
            IFormFile file = Request.Form.Files[0];

            var imageContent = await FileHelpers.ProcessFormFile<T>(
                file, ModelState, FileHelpers.PermittedExtensions, FileHelpers.MaxFileSize);

            if (!ModelState.IsValid)
            {
                return null;
            }

            using var image = Image.Load(imageContent);
            if (image.Width / image.Height < 0.8)
                image.Mutate(i => i.Resize(0, 500));
            else
                image.Mutate(i => i.Resize(400, 0));

            await image.SaveAsJpegAsync(dataStream);
        }
        else
        {
            return null;
        }

        return dataStream;
    }
}
