using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Data;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MySqlTestRazorContext _context;

        public IndexModel(MySqlTestRazorContext context)
        {
            _context = context;
        }

        public IList<Site>? Site { get; set; }

        public async Task OnGetAsync()
        {
            Site = await _context.Sites.ToListAsync();
        }
    }
}