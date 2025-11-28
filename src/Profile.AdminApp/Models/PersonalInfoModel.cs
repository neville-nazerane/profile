using CommunityToolkit.Mvvm.ComponentModel;
using Profile.AdminApp.Utils;
using Profile.Models;

namespace Profile.AdminApp.Models
{
    public partial class PersonalInfoModel : ObservableObject, IMapable<PersonalInfo>
    {
        [ObservableProperty]
        public string? title;

        [ObservableProperty]
        public string? detail;

        public void FromModel(PersonalInfo model)
        {
            Title = model.Title;
            Detail = model.Detail;
        }

        public PersonalInfo ToModel()
        {
            ArgumentNullException.ThrowIfNull(Title);
            ArgumentNullException.ThrowIfNull(Detail);

            return new PersonalInfo
            {
                Title = Title,
                Detail = Detail
            };
        }
    }

}
