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

namespace MySqlTestRazor.Pages.Sites
{
    public class IndexModel : PageModel
    {
        private readonly MySqlTestRazor.Data.MySqlTestRazorContext _context;

        public IndexModel(MySqlTestRazor.Data.MySqlTestRazorContext context)
        {
            _context = context;
        }

        public IList<Site> Site { get;set; }

        public async Task OnGetAsync()
        {
            Site = await _context.Sites.ToListAsync();
        }
    }
}
