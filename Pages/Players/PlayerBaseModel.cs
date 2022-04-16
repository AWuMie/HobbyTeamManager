using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Data;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Pages.Players;

public class PlayerBaseModel : BasePageModel
{
    public SelectList? MembershipTypeSL { get; set; }

    // TODO: generic version that takes a DbSet!?!?
    public void PopulateMemberTypeDropDownList(MySqlTestRazorContext _context,
        object? selectedMembershipTypeId = null)
    {
        var membershipTypeQuery = from mt in _context.MembershipTypes
                                  orderby mt.Id     // sort by Id!
                                  select mt;

        var items = membershipTypeQuery.AsNoTracking().ToList();

        //MembershipTypeSL = new SelectList(items,
        //    "MembershipTypeId", "Name", selectedMembershipTypeId);
        MembershipTypeSL = PopulateDropDownList(items,
            nameof(MembershipType.Id), nameof(MembershipType.Name), selectedMembershipTypeId);
    }
}