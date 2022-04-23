using Microsoft.AspNetCore.Mvc.RazorPages;
using HobbyTeamManager.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace HobbyTeamManager.Pages;

public class BasePageModel : PageModel
{
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
