#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Data;
using MysqlTestConsole.Models;

namespace MySqlTestRazor.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly MySqlTestRazor.Data.MySqlTestRazorContext _context;

        public DetailsModel(MySqlTestRazor.Data.MySqlTestRazorContext context)
        {
            _context = context;
        }

        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players.FirstOrDefaultAsync(m => m.Id == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
