﻿#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Models;
using HobbyTeamManager.Data;

namespace HobbyTeamManager.Pages.Players;

public class IndexModel : PageModel
{
    private readonly HobbyTeamManagerContext _context;

    public IndexModel(HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public IList<Player> Player { get;set; }

    public async Task OnGetAsync()
    {
        Player = await _context.Players.ToListAsync();
    }
}
