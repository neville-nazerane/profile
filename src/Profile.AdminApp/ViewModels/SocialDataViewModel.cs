using Profile.AdminApp.Models;
using Profile.AdminApp.Utils;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.ViewModels
{
    public partial class SocialDataViewModel() : CrudViewModelBase<SocialData, SocialDataModel>(Constants.SOCIAL_DATA_FILE)
    {
    }
}
