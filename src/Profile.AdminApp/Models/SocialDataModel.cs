using CommunityToolkit.Mvvm.ComponentModel;
using Profile.AdminApp.Utils;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.Models
{
    public partial class SocialDataModel : ObservableObject, IMapable<SocialData>
    {
        [ObservableProperty]
        public string? icon;

        [ObservableProperty]
        public string? @class;

        [ObservableProperty]
        public string? url;

        public void FromModel(SocialData model)
        {
            Icon = model.Icon;
            Class = model.Class;
            Url = model.Url;
        }

        public SocialData ToModel()
        {
            ArgumentNullException.ThrowIfNull(Icon);
            ArgumentNullException.ThrowIfNull(Class);
            ArgumentNullException.ThrowIfNull(Url);

            return new SocialData
            {
                Icon = Icon,
                Class = Class,
                Url = Url
            };
        }
    }

}
