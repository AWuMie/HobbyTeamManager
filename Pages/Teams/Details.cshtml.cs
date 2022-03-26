#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        private readonly Data.MySqlTestRazorContext _context;

        public DetailsModel(Data.MySqlTestRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
