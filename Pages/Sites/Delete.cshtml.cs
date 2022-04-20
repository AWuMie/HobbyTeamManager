#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Data;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Sites;

public class DeleteModel : BasePageModel
{
    private readonly MySqlTestRazorContext _context;

    public DeleteModel(MySqlTestRazorContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Site Site { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Site = await _context.Sites.FirstOrDefaultAsync(m => m.Id == id);

        if (Site == null)
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

        Site = await _context.Sites.FindAsync(id);

        if (Site != null)
        {
            _context.Sites.Remove(Site);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
