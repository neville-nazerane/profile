using Profile.AdminApp.Models;
using Profile.AdminApp.Utils;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.ViewModels
{
    public class EducationResumeItemViewModel() : CrudViewModelBase<ResumeItem, ResumeItemModel>(Constants.EDUCATION_RESUME_ITEM_FILE)
    {
    }
}
