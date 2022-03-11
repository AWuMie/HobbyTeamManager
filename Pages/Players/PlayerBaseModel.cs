using Emerholzkicker.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Data;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Players;

public class PlayerBaseModel : PageModel
{
    public SelectList? MembershipTypeSL { get; set; }

    public void PopulateMemberTypeDropDownList(MySqlTestRazorContext _context,
        object? selectedMembershipTypeId = null)
    {
        var membershipTypeQuery = from mt in _context.MembershipTypes
                                  orderby mt.MembershipTypeId     // sort by Id!
                                  select mt;

        var items = membershipTypeQuery.AsNoTracking().ToList();

        MembershipTypeSL = new SelectList(items,
            "MembershipTypeId", "Name", selectedMembershipTypeId);
    }
}