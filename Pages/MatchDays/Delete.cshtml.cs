#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Data;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.MatchDays
{
    public class DeleteModel : PageModel
    {
        private readonly MySqlTestRazor.Data.MySqlTestRazorContext _context;

        public DeleteModel(MySqlTestRazor.Data.MySqlTestRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MatchDay MatchDay { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MatchDay = await _context.MatchDays.FirstOrDefaultAsync(m => m.Id == id);

            if (MatchDay == null)
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

            MatchDay = await _context.MatchDays.FindAsync(id);

            if (MatchDay != null)
            {
                _context.MatchDays.Remove(MatchDay);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
