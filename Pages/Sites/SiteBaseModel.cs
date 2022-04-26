#nullable disable
using HobbyTeamManager.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HobbyTeamManager.Pages.Sites;

public class SiteBaseModel : BasePageModel
{
    public SiteBaseModel(HobbyTeamManagerContext context)
        : base(context) { }

    private SelectList _confirmationModeOptions;
    public SelectList ConfirmationModeOptions
    {
        get { return _confirmationModeOptions; }
        set { _confirmationModeOptions = value; }
    }

    private SelectList _menuPositionOptions;

    public SelectList MenuPositionOptions
    {
        get { return _menuPositionOptions; }
        set { _menuPositionOptions = value; }
    }
}
