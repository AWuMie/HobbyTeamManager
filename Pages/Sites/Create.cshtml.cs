#nullable disable
using Microsoft.AspNetCore.Mvc;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Sites
{
    public class CreateModel : SiteBaseModel
    {
        private readonly HobbyTeamManagerContext _context;

        public CreateModel(HobbyTeamManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ConfirmationModeOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.confirmationMode, "Key", "Value");
            MenuPositionOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.menuPosition, "Key", "Value");
            return Page();
        }

        [BindProperty]
        public Site Site { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ConfirmationModeOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                    Site.ConfirmationModeId);
                MenuPositionOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.menuPosition, "Key", "Value",
                    Site.MenuPositionId);
                return Page();
            }

            var stream = await GetCheckResizeImageAsync<Site>();
            Site.Logo = stream.ToArray();
            
            if (Site.TeamColor1 == Site.TeamColor2)
            {
                ConfirmationModeOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                    Site.ConfirmationModeId);
                MenuPositionOptions = Utilities.Miscellaneous.PopulateDropDownList(Site.menuPosition, "Key", "Value",
                    Site.MenuPositionId);
                return Page();
            }

            _context.Sites.Add(Site);
            await _context.SaveChangesAsync();

            string referer = Request.Headers["Referer"].ToString();
            if (referer != null && Url.IsLocalUrl(referer))
                return RedirectToPage(referer);
            
            return RedirectToPage("./Index");
        }
    }
}
