using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.Data;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Pages.Players;

public class PlayerBaseModel : BasePageModel
{
    public PlayerBaseModel(HobbyTeamManagerContext context)
        : base(context) { }

    public SelectList? MembershipTypeSL { get; set; }

    public void PopulateMemberTypeDropDownList(HobbyTeamManagerContext _context,
        object? selectedMembershipTypeId = null)
    {
        var membershipTypeQuery = from mt in _context.MembershipTypes
                                  orderby mt.Id     // sort by Id!
                                  select mt;

        var items = membershipTypeQuery.AsNoTracking().ToList();

        //MembershipTypeSL = new SelectList(items,
        //    "MembershipTypeId", "Name", selectedMembershipTypeId);
        MembershipTypeSL = Utilities.Miscellaneous.PopulateDropDownList(items,
            nameof(MembershipType.Id), nameof(MembershipType.Name), selectedMembershipTypeId);
    }
}