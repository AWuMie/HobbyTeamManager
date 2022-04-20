#nullable disable
using MySqlTestRazor.Utilities;
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

        //var stream = await GetCheckResizeImageAsync<Player>("NoImage.jpg");
        var stream = await GetCheckResizeImageAsync<Player>();
        Player.ProfilePicture = stream.ToArray();
        //if (stream == null)
        //{
        //    PopulateMemberTypeDropDownList(_context);
        //    return Page();
        //}

        // FIXED: Player Create does not save selected membership type!
        Player.MembershipType =
            _context.MembershipTypes.FirstOrDefault(
                x => x.Id == Player.MembershipTypeId);

        _context.Players.Add(Player);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
