using CommunityToolkit.Mvvm.ComponentModel;
using Profile.AdminApp.Utils;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.Models
{

    public partial class ExperenceStatModel : ObservableObject, IMapable<ExperenceStat>
    {

        [ObservableProperty]
        int yearStarted;

        [ObservableProperty]
        string? label;

        public void FromModel(ExperenceStat model)
        {
            YearStarted = model.YearStarted;
            Label = model.Label;
        }

        public ExperenceStat ToModel()
        {
            ArgumentNullException.ThrowIfNull(Label);

            return new ExperenceStat
            {
                YearStarted = YearStarted,
                Label = Label
            };
        }

    }
}
