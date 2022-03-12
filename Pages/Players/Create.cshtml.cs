#nullable disable
using Emerholzkicker.Utilities;
using Microsoft.AspNetCore.Mvc;
using MySqlTestRazor.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MySqlTestRazor.Pages.Players;

public class CreateModel : PlayerBaseModel
{
    private readonly Data.MySqlTestRazorContext _context;

    public CreateModel(Data.MySqlTestRazorContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        PopulateMemberTypeDropDownList(_context);
        return Page();
    }

    [BindProperty]
    public Player Player { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            PopulateMemberTypeDropDownList(_context);
            return Page();
        }

        using var dataStream = new MemoryStream();
        if (Request.Form.Files.Count > 0)
        {
            // links to checks described in "Areas/Identity/Pages/Account/Manage/Index.cshtml.cs
            IFormFile file = Request.Form.Files[0];

            var imageContent = await FileHelpers.ProcessFormFile<Player>(
                file, ModelState, FileHelpers.PermittedExtensions, FileHelpers.MaxFileSize);

            if (!ModelState.IsValid)
            {
                PopulateMemberTypeDropDownList(_context);
                return Page();
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
            var path = Path.Combine("wwwroot/res", "NoImage.jpg");
            var file = System.IO.File.OpenRead(path);

            await file.CopyToAsync(dataStream);
        }
        Player.ProfilePicture = dataStream.ToArray();

        _context.Players.Add(Player);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
