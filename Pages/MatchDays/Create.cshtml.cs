#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.MatchDays
{
    public class CreateModel : PageModel
    {
        private readonly HobbyTeamManager.Data.HobbyTeamManagerContext _context;

        public CreateModel(HobbyTeamManager.Data.HobbyTeamManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MatchDay MatchDay { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MatchDays.Add(MatchDay);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
