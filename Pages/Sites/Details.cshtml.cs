﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Sites;

public class DetailsModel : BasePageModel
{
    private readonly HobbyTeamManagerContext _context;

    public DetailsModel(HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public Site Site { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Site = await _context.Sites.FirstOrDefaultAsync(m => m.Id == id);

        if (Site == null)
        {
            return NotFound();
        }
        return Page();
    }
}
