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
    public class DetailsModel : PageModel
    {
        private readonly HobbyTeamManager.Data.HobbyTeamManagerContext _context;

        public DetailsModel(HobbyTeamManager.Data.HobbyTeamManagerContext context)
        {
            _context = context;
        }

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
    }
}
