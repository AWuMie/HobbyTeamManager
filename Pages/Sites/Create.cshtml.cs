﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using MySqlTestRazor.Data;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Sites
{
    public class CreateModel : SiteBaseModel
    {
        private readonly MySqlTestRazorContext _context;

        public CreateModel(MySqlTestRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ConfirmationModeOptions = PopulateDropDownList(Site.confirmationMode, "Key", "Value");
            MenuPositionOptions = PopulateDropDownList(Site.menuPosition, "Key", "Value");
            return Page();
        }

        [BindProperty]
        public Site Site { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ConfirmationModeOptions = PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                    Site.ConfirmationModeId);
                MenuPositionOptions = PopulateDropDownList(Site.menuPosition, "Key", "Value",
                    Site.MenuPositionId);
                return Page();
            }

            var stream = await GetCheckResizeImageAsync<Site>();
            Site.Logo = stream.ToArray();
            
            if (Site.TeamColor1 == Site.TeamColor2)
            {
                ConfirmationModeOptions = PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                    Site.ConfirmationModeId);
                MenuPositionOptions = PopulateDropDownList(Site.menuPosition, "Key", "Value",
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
