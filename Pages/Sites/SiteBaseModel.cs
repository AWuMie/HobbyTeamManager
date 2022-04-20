#nullable disable
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MySqlTestRazor.Pages.Sites;

public class SiteBaseModel : BasePageModel
{
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
