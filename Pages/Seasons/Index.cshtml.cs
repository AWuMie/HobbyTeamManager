#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Seasons;

public class IndexModel : PageModel
{
    private readonly Data.MySqlTestRazorContext _context;

    public IndexModel(Data.MySqlTestRazorContext context)
    {
        _context = context;
    }

    public IList<Season> Season { get;set; }

    public async Task OnGetAsync()
    {
        Season = await _context.Seasons.ToListAsync();
    }
}
