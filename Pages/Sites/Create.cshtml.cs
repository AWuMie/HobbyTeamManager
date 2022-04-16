#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlTestRazor.Data;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Sites
{
    public class CreateModel : BasePageModel
    {
        private readonly MySqlTestRazorContext _context;

        private SelectList _confirmationModeOptions;

        public SelectList ConfirmationModeOptions
        {
            get { return _confirmationModeOptions; }
            set { _confirmationModeOptions = value; }
        }

        public CreateModel(MySqlTestRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            _confirmationModeOptions = PopulateDropDownList(Site.confirmationMode, "Key", "Value");
            return Page();
        }

        [BindProperty]
        public Site Site { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                _confirmationModeOptions = PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                    Site.ConfirmationModeId);
                return Page();
            }

            var stream = await GetCheckResizeImageAsync<Site>("NoLogo.jpg");
            if (stream == null || Site.TeamColor1 == Site.TeamColor2)
            {
                _confirmationModeOptions = PopulateDropDownList(Site.confirmationMode, "Key", "Value",
                    Site.ConfirmationModeId);
                return Page();
            }

            Site.Logo = stream.ToArray();

            _context.Sites.Add(Site);
            await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
            string referer = Request.Headers["Referer"].ToString();
            if (referer != null && Url.IsLocalUrl(referer))
                return RedirectToPage(referer);
            
            return RedirectToPage("./Index");
        }
    }
}
