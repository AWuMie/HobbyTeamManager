using Microsoft.AspNetCore.Mvc.RazorPages;
using HobbyTeamManager.Utilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages;

public class BasePageModel : PageModel
{
    private readonly HobbyTeamManagerContext _context;

    public BasePageModel(HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public HobbyTeamManagerContext Context => _context;
}
