#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.MatchDays
{
    public class DeleteModel : PageModel
    {
        private readonly HobbyTeamManager.Data.HobbyTeamManagerContext _context;

        public DeleteModel(HobbyTeamManager.Data.HobbyTeamManagerContext context)
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
