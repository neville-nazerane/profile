using Profile.AdminApp.Models;
using Profile.AdminApp.Utils;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.ViewModels
{
    public partial class PersonalInfoViewModel() : CrudViewModelBase<PersonalInfo, PersonalInfoModel>(Constants.PUBLIC_INFO_FILE)
    {
    }
}
