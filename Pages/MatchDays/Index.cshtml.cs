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
    public class IndexModel : PageModel
    {
        private readonly HobbyTeamManager.Data.HobbyTeamManagerContext _context;

        public IndexModel(HobbyTeamManager.Data.HobbyTeamManagerContext context)
        {
            _context = context;
        }

        public IList<MatchDay> MatchDay { get;set; }

        public async Task OnGetAsync()
        {
            MatchDay = await _context.MatchDays.ToListAsync();
        }
    }
}
