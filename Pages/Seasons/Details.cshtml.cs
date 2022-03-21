#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Seasons;

public class DetailsModel : PageModel
{
    private readonly Data.MySqlTestRazorContext _context;

    public DetailsModel(Data.MySqlTestRazorContext context)
    {
        _context = context;
    }

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
}
