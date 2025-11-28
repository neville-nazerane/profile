using Profile.AdminApp.Models;
using Profile.AdminApp.Utils;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.ViewModels
{
    public partial class SkillInfoViewModel() : CrudViewModelBase<SkillInfo, SkillInfoModel>(Constants.SKILL_INFO_FILE)
    {
    }
}
