#nullable disable
using Emerholzkicker.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MySqlTestRazor.Pages.Players
{
    public class EditModel : PlayerBaseModel
    {
        private readonly MySqlTestRazor.Data.MySqlTestRazorContext _context;

        public EditModel(MySqlTestRazor.Data.MySqlTestRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players
                .Include(p => p.MembershipType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Player == null)
            {
                return NotFound();
            }
            // Select current MembershipTypeId
            PopulateMemberTypeDropDownList(_context, Player.MembershipTypeId);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync(int? id)
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateMemberTypeDropDownList(_context, Player.MembershipTypeId);
                return Page();
            }

            // did we load a new image?
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files[0];

                var imageContent = await FileHelpers.ProcessFormFile<Player>(
                    file, ModelState, FileHelpers.PermittedExtensions, FileHelpers.MaxFileSize);

                if (!ModelState.IsValid)
                {
                    PopulateMemberTypeDropDownList(_context, Player.MembershipTypeId);
                    return Page();
                }

                using var image = Image.Load(imageContent);
                if (image.Width / image.Height < 0.8)
                    image.Mutate(i => i.Resize(0, 500));
                else
                    image.Mutate(i => i.Resize(400, 0));

                using var dataStream = new MemoryStream();
                await image.SaveAsJpegAsync(dataStream);
                Player.ProfilePicture = dataStream.ToArray();
            }

            try
            {
                _context.Update(Player);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(this.Player.Id))
                {
                    return base.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
