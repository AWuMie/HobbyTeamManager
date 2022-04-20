#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Teams;

public class CreateModel : TeamBaseModel
{
    private readonly Data.HobbyTeamManagerContext _context;

    public CreateModel(Data.HobbyTeamManagerContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        PopulateTeamColorDropDownList(_context);
        return Page();
    }

    [BindProperty]
    public Team Team { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            PopulateTeamColorDropDownList(_context, Team.TeamColorId);
            return Page();
        }

        _context.Teams.Add(Team);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
