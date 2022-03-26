#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Seasons
{
    public class DeleteModel : SeasonBaseModel
    {
        private readonly Data.MySqlTestRazorContext _context;

        public DeleteModel(Data.MySqlTestRazorContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Season = await _context.Seasons
                .Include(s => s.MatchDays)              // eager loading!
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Season == null)
            {
                return NotFound();
            }

            SelectedYear = Season.Year;
            SelectedMonth = Season.StartMonth;
            SelectedWeekDay = (int)Season.MatchOnDay;

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
                // get all the related MatchDays and remove them first
                var matchDays = (from md in _context.MatchDays 
                                where md.SeasonId == Season.Id
                                select md).ToList();
                if (matchDays != null && matchDays.Count > 0)
                {
                    _context.MatchDays.RemoveRange(matchDays);
                }
                _context.Seasons.Remove(Season);
                
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
