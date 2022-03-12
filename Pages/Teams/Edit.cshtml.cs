#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Teams;

public class EditModel : TeamBaseModel
{
    private readonly Data.MySqlTestRazorContext _context;

    public EditModel(Data.MySqlTestRazorContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Team Team { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Team = await _context.Teams
            .Include(t => t.TeamColor)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (Team == null)
        {
            return NotFound();
        }

        PopulateTeamColorDropDownList(_context, Team.TeamColorId);

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            PopulateTeamColorDropDownList(_context, Team.TeamColorId);
            return Page();
        }

        //_context.Attach(Team).State = EntityState.Modified;

        try
        {
            _context.Update(Team);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TeamExists(Team.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool TeamExists(int id)
    {
        return _context.Teams.Any(e => e.Id == id);
    }
}
