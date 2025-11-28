using CommunityToolkit.Mvvm.ComponentModel;
using Profile.AdminApp.Utils;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.Models
{
    public partial class SkillInfoModel : ObservableObject, IMapable<SkillInfo>
    {
        [ObservableProperty]
        public string? title;

        [ObservableProperty]
        public string? description;

        [ObservableProperty]
        public int precentage;

        public void FromModel(SkillInfo model)
        {
            Title = model.Title;
            Description = model.Description;
            Precentage = model.Precentage;
        }

        public SkillInfo ToModel()
        {
            ArgumentNullException.ThrowIfNull(Title);
            ArgumentNullException.ThrowIfNull(Description);

            return new SkillInfo
            {
                Title = Title,
                Description = Description,
                Precentage = Precentage
            };
        }
    }

}
