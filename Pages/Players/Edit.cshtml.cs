#nullable disable
using HobbyTeamManager.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace HobbyTeamManager.Pages.Players;

public class EditModel : PlayerBaseModel
{
    public EditModel(Data.HobbyTeamManagerContext context)
        : base(context) { }

    [BindProperty]
    public Player Player { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Player = await Context.Players
            .Include(p => p.MembershipType)         // eager loading!
            .FirstOrDefaultAsync(p => p.Id == id);

        if (Player == null)
        {
            return NotFound();
        }

        // Select current MembershipTypeId
        PopulateMemberTypeDropDownList(Context, Player.MembershipTypeId);

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            PopulateMemberTypeDropDownList(Context, Player.MembershipTypeId);
            return Page();
        }

        var oldProfilePicture = Context.Players
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == Player.Id).ProfilePicture;

        var oldPlayer = Context.Players
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == Player.Id);

        // did we load a new image?
        if (Request.Form.Files.Count > 0)
        {
            var stream = await FileHelpers.GetCheckResizeImageAsync<Player>(Request, ModelState);
            Player.ProfilePicture = stream?.ToArray();

            if (Player.ProfilePicture == null)
                Player.ProfilePicture = oldProfilePicture;
        }
        else if (Player.ProfilePicture != oldProfilePicture)
        {
            Player.ProfilePicture = oldProfilePicture;
        }
        //    IFormFile file = Request.Form.Files[0];

        //    var imageContent = await FileHelpers.ProcessFormFile<Player>(
        //        file, ModelState, FileHelpers.PermittedExtensions, FileHelpers.MaxFileSize);

        //    if (!ModelState.IsValid)
        //    {
        //        PopulateMemberTypeDropDownList(Context, Player.MembershipTypeId);
        //        return Page();
        //    }

        //    using var image = Image.Load(imageContent);
        //    if (image.Width / image.Height < 0.8)
        //        image.Mutate(i => i.Resize(0, 500));
        //    else
        //        image.Mutate(i => i.Resize(400, 0));

        //    using var dataStream = new MemoryStream();
        //    await image.SaveAsJpegAsync(dataStream);
        //    Player.ProfilePicture = dataStream.ToArray();
        //}

        // FIXED: if we did not change the ProfilePicture in Player it is null here!
        //if (Player.ProfilePicture == null)
        //{
        //    Player.ProfilePicture = Context.Players
        //        .AsNoTracking()
        //        .FirstOrDefault(p => p.Id == Player.Id).ProfilePicture;
        //}

        //try
        //{
        //    // FIXED:membershiptype selection lost as well
        //    Player.MembershipType =
        //        Context.MembershipTypes.FirstOrDefault(
        //            x => x.Id == Player.MembershipTypeId);

        //    Context.Update(Player);
        //    await Context.SaveChangesAsync();
        //}

        Context.Attach(Player).State = EntityState.Modified;
        Context.Update(Player);

        try
        {
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PlayerExists(this.Player.Id))
            {
                return base.NotFound();
            }
            else
            {
                if (oldPlayer.RowVersion != Player.RowVersion)
                {
                    throw;
                }
                else
                {
                    // hmmmm?
                    PopulateMemberTypeDropDownList(Context, Player.MembershipTypeId);
                    return Page();
                }
            }
        }

        return RedirectToPage("./Index");
    }

    private bool PlayerExists(int id)
    {
        return Context.Players.Any(p => p.Id == id);
    }
}
