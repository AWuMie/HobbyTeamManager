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
    public class IndexAdminModel : PageModel
    {
        private readonly MySqlTestRazor.Data.MySqlTestRazorContext _context;

        public IndexAdminModel(MySqlTestRazor.Data.MySqlTestRazorContext context)
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
