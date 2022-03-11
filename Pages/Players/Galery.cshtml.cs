﻿#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Players
{
    public class GaleryModel : PageModel
    {
        private readonly MySqlTestRazor.Data.MySqlTestRazorContext _context;

        public GaleryModel(MySqlTestRazor.Data.MySqlTestRazorContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; }

        public async Task OnGetAsync()
        {
            Player = await _context.Players.ToListAsync();
        }
    }
}