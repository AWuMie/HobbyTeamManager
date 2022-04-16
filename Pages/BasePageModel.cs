using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlTestRazor.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Collections;

namespace MySqlTestRazor.Pages
{
    public class BasePageModel : PageModel
    {
        public string BgColorBody { get; set; } = "#000000";    // black
        public string FgColorBody { get; set; } = "#ffa500";    // orange
        public string BgColorHeader { get; set; } = "#000000";
        public string FgColorHeader { get; set; } = "#ffa500";
        public string BgColorMain { get; set; } = "#000000";
        public string FgColorMain { get; set; } = "#ffa500";
        public string BgColorFooter { get; set; } = "#000000";
        public string FgColorFooter { get; set; } = "#ffa500";
        public string Headline { get; set; } = "Hobby Team Manager";
        public string Headline2 { get; set; } = "";

        public SelectList PopulateDropDownList(IEnumerable collection,
            string value, string data, object? selectedItem = null)
        {
            return new SelectList(collection, value, data, selectedItem);
        }

        public async Task<MemoryStream?> GetCheckResizeImageAsync<T>(string noImage)
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
                var path = Path.Combine("wwwroot/res", noImage);
                var file = System.IO.File.OpenRead(path);

                await file.CopyToAsync(dataStream);
            }

            return dataStream;
        }
    }
}
