using CommunityToolkit.Mvvm.ComponentModel;
using Profile.AdminApp.Utils;
using Profile.Models;

namespace Profile.AdminApp.Models
{
    public partial class ResumeItemModel : ObservableObject, IMapable<ResumeItem>
    {
        [ObservableProperty]
        public string? title;

        [ObservableProperty]
        public string? location;

        [ObservableProperty]
        public string? description;

        [ObservableProperty]
        public string? from;

        [ObservableProperty]
        public string? to;

        public void FromModel(ResumeItem model)
        {
            Title = model.Title;
            Location = model.Location;
            Description = model.Description;
            From = model.From;
            To = model.To;
        }

        public ResumeItem ToModel()
        {
            ArgumentNullException.ThrowIfNull(Title);
            ArgumentNullException.ThrowIfNull(Location);
            ArgumentNullException.ThrowIfNull(Description);

            return new ResumeItem
            {
                Title = Title,
                Location = Location,
                Description = Description,
                From = From,
                To = To
            };
        }
    }

}
