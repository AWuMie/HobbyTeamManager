#nullable disable
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HobbyTeamManager.Pages.Sites;

public class HomeModel : BasePageModel
{
    private readonly HobbyTeamManagerContext _context;

    public HomeModel(HobbyTeamManagerContext context)
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

        HttpContext.Session.SetString("Site", JsonConvert.SerializeObject(Site));
        //var site = JsonConvert.DeserializeObject<Site>(HttpContext.Session.GetString("Site"));
        UpdateBaseProperties(Site);

        return Page();
    }
}
