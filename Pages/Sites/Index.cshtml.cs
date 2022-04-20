#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Sites
{
    public class IndexModel : BasePageModel
    {
        private readonly HobbyTeamManagerContext _context;

        public IndexModel(HobbyTeamManagerContext context)
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
