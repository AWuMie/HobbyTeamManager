#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Seasons
{
    public class DeleteModel : PageModel
    {
        private readonly Data.MySqlTestRazorContext _context;

        public DeleteModel(Data.MySqlTestRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Season Season { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Season = await _context.Seasons.FirstOrDefaultAsync(m => m.Id == id);

            if (Season == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Season = await _context.Seasons.FindAsync(id);

            if (Season != null)
            {
                _context.Seasons.Remove(Season);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
