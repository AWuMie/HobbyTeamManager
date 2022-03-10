using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Data;

namespace MySqlTestRazor.Pages.Players;

public class PlayerBaseModel : PageModel
{
    public SelectList? MembershipTypeSL { get; set; }

    public void PopulateMemberTypeDropDownList(MySqlTestRazorContext _context,
        object? selectedMembershipTypeId = null)
    {
        var membershipTypeQuery = from mt in _context.MembershipTypes
                              orderby mt.Id     // sort by Id!
                              select mt;

        var items = membershipTypeQuery.AsNoTracking().ToList();

        MembershipTypeSL = new SelectList(items,
            "Id", "Name", selectedMembershipTypeId);
    }
}
