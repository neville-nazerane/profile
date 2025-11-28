using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Profile.AdminApp.Models;
using Profile.AdminApp.Services;
using Profile.AdminApp.Utils;
using Profile.Models;
using System.Collections.ObjectModel;

namespace Profile.AdminApp.ViewModels
{
    public partial class ExperienceStatsViewModel() : CrudViewModelBase<ExperenceStat, ExperenceStatModel>(Constants.EXPERIENCE_STATS_FILE)
    {

    }
}
